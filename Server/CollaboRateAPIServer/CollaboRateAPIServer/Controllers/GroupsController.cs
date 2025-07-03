using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CollaboRateAPIServer.Data;
using System.Runtime.Versioning;
using CollaboRateAPIServer.Dtos;
using CollaboRateAPIServer.Models;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/groups/user
        // Gets all groups (Group ID and Name) that the user with the specified User_ID is in
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroupsForUser(int userId)
        {
            var groups = await _context.tblGroupMember
                .Where(gm => gm.User_ID == userId && gm.Join_Status == "Accepted")
                .Include(gm => gm.Group)
                .Select(gm => new GroupDto
                {
                    Group_ID = gm.Group.Group_ID,
                    Group_Name = gm.Group.Group_Name
                })
                .ToListAsync();

            if (groups == null || groups.Count == 0)
            {
                return NotFound("No groups found for user with ID " + userId);
            }

            return Ok(groups);
        }

        // GET: api/groups/{groupId}/details-with-accepted-users
        [HttpGet("{groupId}/details-with-accepted-users")]
        public async Task<ActionResult<AcceptedGroupUsersDto>> GetGroupsWithAcceptedUsers(int groupId)
        {
            var groupData = await _context.tblGroup
                .Where(g => g.Group_ID == groupId)
                .Select(g => new AcceptedGroupUsersDto
                {
                    Group_ID = g.Group_ID,
                    Group_Name = g.Group_Name,
                    Group_Description = g.Group_Description,
                    Accepted_Users = g.GroupMembers
                        .Where(gm => gm.Join_Status == "Accepted")
                        .Select(gm => new GroupUserDto
                        {
                            User_ID = gm.User.User_ID,
                            Username = gm.User.Username,
                            User_Role = gm.User_Role
                        })
                        .ToList(),
                    Accepted_User_Count = g.GroupMembers.Count(gm => gm.Join_Status == "Accepted")
                })
                .FirstOrDefaultAsync();

            if (groupData == null)
            {
                return NotFound("Group with ID " + groupId + " not found.");
            }

            return Ok(groupData);
        }

        // Method to get users that are not accepted
        // GET: api/groups/{groupId}/pending-users
        [HttpGet("{groupId}/pending-users")]
        public async Task<ActionResult<List<PendingUserDto>>> GetPendingUsers(int groupId)
        {
            bool groupExists = await _context.tblGroup.AnyAsync(g => g.Group_ID == groupId);
            if (!groupExists)
            {
                return NotFound("Group with ID: " + groupId + " not found.");
            }

            var pendingUsers = await _context.tblGroupMember
                .Where(gm => gm.Group_ID == groupId && gm.Join_Status == "Pending")
                .Include(gm => gm.User)
                .Select(gm => new PendingUserDto
                {
                    User_ID = gm.User.User_ID,
                    Username = gm.User.Username
                })
                .ToListAsync();

            return Ok(pendingUsers);
        }

        // Method to get groups
        [HttpGet("available-groups")]
        public async Task<ActionResult<List<GroupWithRequestStatusDto>>> GetAvailableGroupsForUser([FromQuery] int userId)
        {
            var groups = await _context.tblGroup
                .Where(g => !_context.tblGroupMember
                    .Any(gm => gm.Group_ID == g.Group_ID && gm.User_ID == userId && gm.Join_Status == "Accepted"))
                .Select(g => new GroupWithRequestStatusDto
                {
                    Group_ID = g.Group_ID,
                    Group_Name = g.Group_Name,
                    HasPendingRequest = _context.tblGroupMember
                        .Any(gm => gm.Group_ID == g.Group_ID && gm.User_ID == userId && gm.Join_Status == "Pending")
                })
                .ToListAsync();

            return Ok(groups);
        }

        // Method to request to join a group
        [HttpPost("{groupId}/join-requests/{userId}")]
        public async Task<IActionResult> RequestToJoinGroup(int groupId, int userId)
        {
            var groupExits = await _context.tblGroup.AnyAsync(g => g.Group_ID == groupId);

            if (!groupExits)
            {
                return NotFound("Group not found.");
            }

            bool alreadyMemberOrPending = await _context.tblGroupMember.AnyAsync(gm =>
                gm.Group_ID == groupId &&
                gm.User_ID == userId &&
                (gm.Join_Status == "Accepted" || gm.Join_Status == "Pending"));

            if (alreadyMemberOrPending)
            {
                return BadRequest("User is already a member or has a pending request.");
            }

            // Get current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Find the South Africa time zone (Africa/Johannesburg)
            TimeZoneInfo southAfricaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time");

            // Convert UTC to South Africa time
            DateTime southAfricaTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, southAfricaTimeZone);

            var membership = new GroupMember
            {
                Group_ID = groupId,
                User_ID = userId,
                Join_Status = "Pending",
                User_Role = "Member",
                Joined_At = southAfricaTime
            };

            _context.tblGroupMember.Add(membership);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Method to cancel a join request
        [HttpDelete("{groupId}/join-requests/{userId}")]
        public async Task<IActionResult> CancelJoinRequest(int groupId, int userId)
        {
            var membership = await _context.tblGroupMember.FirstOrDefaultAsync(gm =>
                gm.Group_ID == groupId &&
                gm.User_ID == userId &&
                gm.Join_Status == "Pending");

            if (membership == null)
            {
                return NotFound("No pending join request found for this user in the group.");
            }

            _context.tblGroupMember.Remove(membership);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Method to accept a user to the group and send notification
        [HttpPut("{groupId}/members/{userId}/accept")]
        public async Task<IActionResult> AcceptUserToGroup(int groupId, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Find pending membership
                var membership = await _context.tblGroupMember
                    .FirstOrDefaultAsync(gm => gm.Group_ID == groupId && gm.User_ID == userId && gm.Join_Status == "Pending");

                if (membership == null)
                {
                    return NotFound("Pending membership not found.");
                }

                // Update membership status
                membership.Join_Status = "Accepted";
                membership.User_Role = "Member";
                membership.Joined_At = DateTime.UtcNow;

                // Create a notification
                var notification = new GroupNotification
                {
                    Group_ID = groupId,
                    Notification_Type = "Membership Accepted",
                    Notification_Message = $"You have been accepted to group {groupId}.",
                    Created_At = DateTime.UtcNow
                };

                _context.tblGroupNotification.Add(notification);
                await _context.SaveChangesAsync(); // Save to get Group_Notification_ID

                // Create notification recipient
                var recipient = new NotificationRecipient
                {
                    Group_Notification_ID = notification.Group_Notification_ID,
                    User_ID = userId,
                    Is_Read = false
                };
                _context.tblNotificationRecipient.Add(recipient);

                // Save all changes atomically
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                //return StatusCode(500, "An error occurred while accepting the user and sending notification.");
                return StatusCode(500, $"An error occurred: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // Method to reject a join request and send notification
        [HttpDelete("{groupId}/members/{userId}/reject")]
        public async Task<IActionResult> RejectUserFromGroup(int groupId, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Find the pending membership
                var membership = await _context.tblGroupMember
                    .FirstOrDefaultAsync(gm => gm.Group_ID == groupId && gm.User_ID == userId && gm.Join_Status == "Pending");

                if (membership == null)
                {
                    return NotFound("Pending membership not found.");
                }

                // Remove the membership request
                _context.tblGroupMember.Remove(membership);

                // Create a notification
                var notification = new GroupNotification
                {
                    Group_ID = groupId,
                    Notification_Type = "Membership Rejected",
                    Notification_Message = $"Your request to join group {groupId} has been rejected.",
                    Created_At = DateTime.UtcNow
                };

                _context.tblGroupNotification.Add(notification);

                // Save all changes 
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while rejecting the user and sending notification.");
            }
        }
    }
}
