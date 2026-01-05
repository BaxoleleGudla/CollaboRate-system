using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using System.Collections.Generic;
using CollaboRateAPIServer.Data;
using System.Runtime.Versioning;
using CollaboRateAPIServer.Dtos;
using CollaboRateAPIServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.SignalR;
using CollaboRateAPIServer.Hubs;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public GroupsController(AppDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
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
        public async Task<ActionResult<List<GroupWithRequestStatusDto>>> GetAvailableGroupsForUser([FromQuery] int userId, [FromQuery] string keyword = null)
        {
            // Base query: groups where user is not acceted
            IQueryable<Group> query = _context.tblGroup
                .Where(g => !_context.tblGroupMember
                    .Any(gm => gm.Group_ID == g.Group_ID && gm.User_ID == userId && gm.Join_Status == "Accepted"));

            // Apply keywork filter if provided
            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                string lowerKeyword = keyword.ToLower();
                query = query.Where(g => g.Group_Name.ToLower().Contains(lowerKeyword));
            }

            // Project to DTO with pending request info
            var groups = await query
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

        // Helper Method inside GroupsController
        private async Task NotifyAdminsOfPendingChange(int groupId)
        {
            // 1. Get the fresh list from DB
            var pendingUsers = await _context.tblGroupMember
                .Where(gm => gm.Group_ID == groupId && gm.Join_Status == "Pending")
                .Select(gm => new PendingUserDto
                {
                    User_ID = gm.User_ID,
                    Username = gm.User.Username
                }).ToListAsync();

            // 2. Broadcast to the specific "Room"
            string groupName = $"Group_Admin_Room_{groupId}";
            await _hubContext.Clients.Group(groupName).SendAsync("RefreshPendingList", pendingUsers);
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

            // Trigger the real-time update
            await NotifyAdminsOfPendingChange(groupId);

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

            // Trigger the real-time update
            await NotifyAdminsOfPendingChange(groupId);

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

                // Trigger the real-time update
                await NotifyAdminsOfPendingChange(groupId);

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

                // Trigger the real-time update
                await NotifyAdminsOfPendingChange(groupId);

                return NoContent();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while rejecting the user and sending notification.");
            }
        }

        // Method to create a new group
        [HttpPost("groups")]
        public async Task<ActionResult<CreateGroupResponse>> CreateGroup([FromBody] CreateGroupRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Insert new group
                var group = new Group
                {
                    Group_Name = request.Group_Name,
                    Group_Description = request.Group_Description,
                    Creator = request.Creator,
                    Created_At = DateTime.UtcNow
                };

                _context.tblGroup.Add(group);
                await _context.SaveChangesAsync();

                // Add creator as Admin member
                var creatorMember = new GroupMember
                {
                    Group_ID = group.Group_ID,
                    User_ID = request.Creator,
                    User_Role = "Admin",
                    Join_Status = "Accepted",
                    Joined_At = DateTime.UtcNow
                };

                _context.tblGroupMember.Add(creatorMember);

                // Add other members
                foreach (var userId in request.Member_User_IDs.Distinct())
                {
                    if (userId == request.Creator)
                    {
                        continue;
                    }

                    var member = new GroupMember
                    {
                        Group_ID = group.Group_ID,
                        User_ID = userId,
                        User_Role = "Member",
                        Join_Status = "Accepted",
                        Joined_At = DateTime.UtcNow
                    };

                    _context.tblGroupMember.Add(member);
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(new CreateGroupResponse { Group_ID = group.Group_ID });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return StatusCode(500, "An error occurred while creating the group.");
            }
        }

        // Method to update a group
        [HttpPut("update-group")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupRequest request)
        {
            if (request == null || request.Group_ID <= 0)
            {
                return BadRequest("Invalid group data.");
            }

            // Start a transaction for atomic update
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Fetch the group entity including menbers
                var group = await _context.tblGroup
                    .Include(g => g.GroupMembers)
                    .FirstOrDefaultAsync(g => g.Group_ID == request.Group_ID);

                if (group == null)
                {
                    return NotFound("Group with ID " + request.Group_ID + " not found.");
                }

                // Update group name and description
                group.Group_Name = request.Group_Name;
                group.Group_Description = request.Group_Description;

                // Update member roles
                foreach (var memberDto in request.Members)
                {
                    var memberEntity = group.GroupMembers.FirstOrDefault(m => m.User_ID == memberDto.User_ID);

                    if (memberEntity != null)
                    {
                        memberEntity.User_Role = memberDto.User_Role;
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { Message = "Group and member roles updated successfully." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return StatusCode(500, "An error occourred while updating the group.");
            }
        }

        // Method to add additional members to the group
        [HttpPost("add-users")]
        public async Task<IActionResult> AddUsersToGroup([FromBody] AddUsersToGroupRequest request)
        {
            if (request == null || request.Group_ID <= 0 || request.User_IDs == null || !request.User_IDs.Any())
            {
                return BadRequest("Invalid group Id or user list.");
            }

            try
            {
                // Validate group exists
                var groupExists = await _context.tblGroup.AnyAsync(g => g.Group_ID == request.Group_ID);

                if (!groupExists)
                {
                    return NotFound("Group with ID " + request.Group_ID + " not found.");
                }

                // Get existing members in group to avoid duplicates
                var existingUserIds = await _context.tblGroupMember
                    .Where(gm => gm.Group_ID == request.Group_ID && request.User_IDs.Contains(gm.User_ID))
                    .Select(gm => gm.User_ID)
                    .ToListAsync();

                // Filter out users already in the group
                var newUserIds = request.User_IDs.Except(existingUserIds).ToList();

                if (!newUserIds.Any())
                {
                    return Ok(new { Message = "No new users to add. All users are already members." });
                }

                // Create new group member entries
                var newGroupMembers = newUserIds.Select(userId => new GroupMember
                {
                    Group_ID = request.Group_ID,
                    User_ID = userId,
                    User_Role = "Member",
                    Join_Status = "Accepted",
                    Joined_At = DateTime.UtcNow
                }).ToList();

                await _context.tblGroupMember.AddRangeAsync(newGroupMembers);

                await _context.SaveChangesAsync();

                return Ok(new { Message = newUserIds.Count + " user(s) added to the group successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding users to the group.");
            }
        }

        // Method to get users in a group
        [HttpGet("group/{groupId}/users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByGroup(int groupId, [FromQuery] string? keyword = null)
        {
            try
            {
                // Base query
                var query = _context.tblGroupMember
                    .Where(gm => gm.Group_ID == groupId && gm.Join_Status == "Accepted")
                    .Select(gm => gm.User);

                // Apply keyword filter if provided
                if (string.IsNullOrWhiteSpace(keyword) == false)
                {
                    string lowerKeyword = keyword.ToLower();
                    query = query.Where(u =>
                    u.Username.ToLower().Contains(lowerKeyword));
                }

                var users = await query
                    .OrderBy(u => u.Username)
                    .Select(u => new UserDto
                    {
                        User_ID = u.User_ID,
                        Username = u.Username
                    })
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // Method to remove a member from a group
        [HttpDelete("{groupId}/members/{userId}")]
        public async Task<IActionResult> RemoveUserFromGroup(int groupId, int userId)
        {
            if (groupId <= 0 || userId <= 0)
            {
                return BadRequest("Invalid group or user ID.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var group = await _context.tblGroup.FirstOrDefaultAsync(g => g.Group_ID == groupId);

                if (group == null)
                {
                    return NotFound("Group not found.");
                }

                // Check if membership exists
                var membership = await _context.tblGroupMember.FirstOrDefaultAsync(gm => gm.Group_ID == groupId && gm.User_ID == userId);

                if (membership == null)
                {
                    return NotFound("User is not a member of this group.");
                }

                // Check if user is the last admin in the group
                if (membership.User_Role == "Admin")
                {
                    int adminCount = await _context.tblGroupMember.CountAsync(gm => gm.Group_ID == groupId && gm.Join_Status == "Accepted" && gm.User_Role == "Admin");

                    if (adminCount <= 1)
                    {
                        return BadRequest("Cannot remove the last admin from the group.");
                    }
                }

                // Remove the member
                _context.tblGroupMember.Remove(membership);
                await _context.SaveChangesAsync();

                // Create a notification about removal
                var notification = new GroupNotification
                {
                    Group_ID = groupId,
                    Notification_Type = "Membership Removed",
                    Notification_Message = $"You have been removed from group {group.Group_Name}",
                    Created_At = DateTime.UtcNow
                };

                _context.tblGroupNotification.Add(notification);
                await _context.SaveChangesAsync();

                var recipient = new NotificationRecipient
                {
                    Group_Notification_ID = notification.Group_Notification_ID,
                    User_ID = userId,
                    Is_Read = false
                };
                _context.tblNotificationRecipient.Add(recipient);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while removing the member.");
            }
        }

        // Method to get a member role from a group
        [HttpGet("users/{userId}/groups/{groupId}/role")]
        public async Task<IActionResult> GetUserGroupRole(int userId, int groupId)
        {
            if (userId <= 0 || groupId <= 0)
            {
                return BadRequest("Invalid user ID or group ID.");
            }

            try
            {
                var memberRole = await _context.tblGroupMember
                    .AsNoTracking()
                    .Where(m => m.User_ID == userId && m.Group_ID == groupId && m.Join_Status == "Accepted")
                    .Select(m => new
                    {
                        User_Role = m.User_Role
                    })
                    .FirstOrDefaultAsync();

                if (memberRole == null)
                {
                    return Ok(new
                    {
                        User_Role = "NoRole"
                    });
                }

                return Ok(new
                {
                    User_Role = memberRole.User_Role
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error retrieving user role.", detail = ex.Message });
            }
        }
    }
}
