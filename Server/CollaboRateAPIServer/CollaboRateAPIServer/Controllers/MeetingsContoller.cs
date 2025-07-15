using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CollaboRateAPIServer.Data;
using System.Runtime.Versioning;
using CollaboRateAPIServer.Dtos;
using CollaboRateAPIServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeetingsController(AppDbContext context)
        {
            _context = context;
        }

        // Method to get meetings for a group
        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetMeetingsByGroup(int groupId, [FromQuery] string? keyword = null)
        {
            try
            {
                // Base query filtered by Group_ID
                var query = _context.tblMeeting
                    .Where(m => m.Group_ID == groupId);

                // Apply keword filter if provied
                if (string.IsNullOrWhiteSpace(keyword) == false)
                {
                    string lowerKeyword = keyword.ToLower();
                    query = query.Where(m =>
                        m.Meeting_Title.ToLower().Contains(lowerKeyword) ||
                        (m.Meeting_Description != null && m.Meeting_Description.ToLower().Contains(lowerKeyword)));
                }

                var meetings = await query
                    .OrderBy(m => m.Meeting_Date)
                    .Select(m => new MeetingDto
                    {
                        Meeting_ID = m.Meeting_ID,
                        Meeting_Title = m.Meeting_Title,
                        Meeting_Description = m.Meeting_Description,
                        Meeting_Date = m.Meeting_Date
                    })
                    .ToListAsync();

                if (meetings == null || !meetings.Any())
                {
                    return NotFound("No meetings found for Group ID " + groupId + ".");
                }

                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while processing your request.");
            }
        }

        // Method to create  a new meeting
        [HttpPost]
        public async Task<ActionResult> CreateMeeting([FromBody] CreateMeetingDto meetingDto)
        {
            // Use a transaction to ensure atomicity
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Add new meeting
                var meeting = new Meeting
                {
                    Group_ID = meetingDto.Group_ID,
                    Meeting_Title = meetingDto.Meeting_Title,
                    Meeting_Description = meetingDto.Meeting_Description,
                    Meeting_Date = meetingDto.Meeting_Date
                };
                _context.tblMeeting.Add(meeting);
                await _context.SaveChangesAsync();

                // Get the group name for notification message
                var group = await _context.tblGroup
                    .Where(g => g.Group_ID == meetingDto.Group_ID)
                    .Select(g => new { g.Group_ID, g.Group_Name })
                    .FirstOrDefaultAsync();

                if (group == null)
                {
                    return BadRequest("Invalid Group ID.");
                }

                // Create the group notification
                string notificationMessage = $"New meeting scheduled for group {group.Group_Name} on {meeting.Meeting_Date:dddd, MMMM d, yyyy HH:mm}.";

                var groupNotification = new GroupNotification
                {
                    Group_ID = group.Group_ID,
                    Notification_Type = "Meeting Scheduled",
                    Notification_Message = notificationMessage,
                };
                _context.tblGroupNotification.Add(groupNotification);
                await _context.SaveChangesAsync();

                // Get all users in the group to notify
                var userIds = await _context.tblGroupMember
                    .Where(gm => gm.Group_ID == meetingDto.Group_ID)
                    .Select(gm => gm.User_ID)
                    .ToListAsync();

                // Create notification recipients for each user
                var notificationRecipients = userIds.Select(userId => new NotificationRecipient
                {
                    Group_Notification_ID = groupNotification.Group_Notification_ID,
                    User_ID = userId,
                    Is_Read = false
                }).ToList();

                _context.tblNotificationRecipient.AddRange(notificationRecipients);
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                return CreatedAtAction(nameof(GetMeetingById), new { id = meeting.Meeting_ID }, meeting);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return StatusCode(500, "An error occured while creating the meeting and notifications.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeetingById(int id)
        {
            var meeting = await _context.tblMeeting.FindAsync();
            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }

        // Method to update a meeting
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMeeting(int id, [FromBody] UpdateMeetingDto meetingDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Find existing meeting
                var meeting = await _context.tblMeeting.FindAsync(id);
                if (meeting == null)
                {
                    return NotFound("Meeting not found.");
                }

                // Update meeting properties
                meeting.Meeting_Title = meetingDto.Meeting_Title;
                meeting.Meeting_Description = meetingDto.Meeting_Description;
                meeting.Meeting_Date = meetingDto.Meeting_Date;

                await _context.SaveChangesAsync();

                // Get the updated group info
                var group = await _context.tblGroup
                    .Where(g => g.Group_ID == meeting.Group_ID)
                    .Select(g => new { g.Group_ID, g.Group_Name })
                    .FirstOrDefaultAsync();

                if (group == null)
                {
                    return BadRequest("Invalid Group ID associated with the meeting.");
                }

                // Create a notification about the update
                string notificationMessage = $"Meeting for group {group.Group_Name}  has been updated and is now scheduled for {meeting.Meeting_Date:dddd, d MMMM, yyyy HH:mm}.";

                var groupNotification = new GroupNotification
                {
                    Group_ID = group.Group_ID,
                    Notification_Type = "Meeting Updated",
                    Notification_Message = notificationMessage
                };
                _context.tblGroupNotification.Add(groupNotification);
                await _context.SaveChangesAsync();

                // Get all users in the group to notify them about the update
                var userIds = await _context.tblGroupMember
                    .Where(gm => gm.Group_ID == group.Group_ID)
                    .Select(gm => gm.User_ID)
                    .ToListAsync();

                var notificationRecipients = userIds.Select(userId => new NotificationRecipient
                {
                    Group_Notification_ID = groupNotification.Group_Notification_ID,
                    User_ID = userId,
                    Is_Read = false
                }).ToList();

                _context.tblNotificationRecipient.AddRange(notificationRecipients);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(meeting);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occured while updating the meeting and notifications.");
            }
        }
    }
}
