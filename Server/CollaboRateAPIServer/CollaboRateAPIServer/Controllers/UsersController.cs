using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Models;
using CollaboRateAPIServer.Dtos;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        // Get all users from the database
        [HttpGet("users")]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] int? currentUserId = null, [FromQuery] string? keyword = null)
        {
            IQueryable<User> query = _context.tblUser;

            if (currentUserId.HasValue)
            {
                query = query.Where(u => u.User_ID != currentUserId.Value);
            }

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                string lowerKeyword = keyword.ToLower();
                query = query.Where(u => u.Username.ToLower().Contains(lowerKeyword));
            }

            var users = await query
                .Select(u => new UserDto
                {
                    User_ID = u.User_ID,
                    Username = u.Username
                })
                .ToListAsync();

            return Ok(users);
        }

        // Get all users not in current group
        [HttpGet("not-in-group/{currentGroupId}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersNotInGroup(int currentGroupId, [FromQuery] int currentUserId, [FromQuery] string? keyword = null)
        {
            if (currentUserId <= 0 || currentGroupId <= 0)
            {
                return BadRequest("User ID and Group ID must be positive values.");
            }

            try
            {
                // Get IDs of users already in the current group
                var memberIdsInGroup = await _context.tblGroupMember
                    .Where(gm => gm.Group_ID == currentGroupId)
                    .Select(gm => gm.User_ID)
                    .ToListAsync();

                // Query for users not in the group
                var query = _context.tblUser
                    .Where(u => !memberIdsInGroup.Contains(u.User_ID) && u.User_ID != currentUserId);

                // Apply search keyword filter if provided
                if (string.IsNullOrWhiteSpace(keyword) == false)
                {
                    string lowerKeyword = keyword.ToLower();
                    query = query.Where(u => u.Username.ToLower().Contains(lowerKeyword));
                }

                var users = await query
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
                return StatusCode(500, "An error occurred while getting users.");
            }
        }

        // GET: api/users/
        // Get a single user by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.tblUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Method to get users in a group with task assignment
        [HttpGet("group/{groupId}/task/{taskId}/users")]
        public async Task<ActionResult<List<UserWithTaskAssignmentDto>>> GetUsersInGroupWithTaskAssignmentAsync(int groupId, int taskId)
        {
            try
            {
                var query = from user in _context.tblUser
                           join groupMember in _context.tblGroupMember
                                on user.User_ID equals groupMember.User_ID
                           where groupMember.Group_ID == groupId
                           select new
                           {
                               user.User_ID,
                               user.Username,
                               IsInTask = _context.tblTaskAssignment
                                    .Any(ta => ta.Task_ID == taskId && ta.User_ID == user.User_ID)
                           };

                var users = await query
                    .OrderByDescending(u => u.IsInTask) // Assigned users first
                    .ThenBy(u => u.Username)
                    .ToListAsync();

                var result = users.Select(u => new UserWithTaskAssignmentDto
                {
                    User_ID = u.User_ID,
                    Username = u.Username,
                    IsInTask = u.IsInTask
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while retrieving users. " + ex.Message);
            }
        }

        // POST: api/users
        // Adds a new user to the database
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.tblUser.Add(user);
            await _context.SaveChangesAsync();

            var responseDto = new UserRegisterResponseDto
            {
                User_ID = user.User_ID,
                Username = user.Username,
                Email = user.Email,
                Created_At = user.Created_At
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.User_ID }, responseDto);
        }

        // PUT: api/users/
        // Updates an existing user by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.User_ID)
            {
                return BadRequest("User ID mismatch");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/users/
        // Delete a user by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.tblUser.FindAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            // Execute everything within an atomic transaction to preserve DB integrity
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Fetch all groups where the user is either the Creator OR an active Admin
                var groupsToHandle = await _context.tblGroup
                    .Where(g => g.Creator == id || _context.tblGroupMember.Any(gm =>
                        gm.Group_ID == g.Group_ID &&
                        gm.User_ID == id &&
                        gm.User_Role == "Admin" &&
                        gm.Join_Status == "Accepted"))
                    .ToListAsync();

                foreach (var group in groupsToHandle)
                {
                    bool isCreator = (group.Creator == id);

                    bool isAdmin = await _context.tblGroupMember.AnyAsync(gm =>
                        gm.Group_ID == group.Group_ID &&
                        gm.User_ID == id &&
                        gm.User_Role == "Admin" &&
                        gm.Join_Status == "Accepted");

                    // Check if there are any OTHER active admins left in this group
                    var otherAdmin = await _context.tblGroupMember
                        .Where(gm => gm.Group_ID == group.Group_ID && gm.User_ID != id && gm.User_Role == "Admin" && gm.Join_Status == "Accepted")
                        .OrderBy(gm => gm.Joined_At)
                        .FirstOrDefaultAsync();

                    // Case A: The user is the sole Admin, meaning we must promote someone
                    if (isAdmin && otherAdmin == null)
                    {
                        var successor = await _context.tblGroupMember
                            .Where(gm => gm.Group_ID == group.Group_ID && gm.User_ID != id && gm.Join_Status == "Accepted")
                            .OrderBy(gm => gm.Joined_At)
                            .FirstOrDefaultAsync();

                        if (successor != null)
                        {
                            // Promote the oldest regular member to Admin
                            successor.User_Role = "Admin";

                            // If the deleting user was also the creator, pass ownership to the new admin
                            if (isCreator)
                            {
                                group.Creator = successor.User_ID;
                            }
                        }
                        else
                        {
                            // No other accepted members are left in the group at all, purge the entire group
                            await PurgeGroupEntirelyAsync(group.Group_ID);
                            continue;
                        }
                    }
                    // Case B: They aren't the sole Admin, but they ARE the Creator.
                    // Pass the Creator flag smoothly to an existing Admin.
                    else if (isCreator && otherAdmin != null)
                    {
                        group.Creator = otherAdmin.User_ID;
                    }
                }

                // 2. Cascade Delete all personal user footprints across the database

                // Remove Task Assignments
                var assignments = _context.tblTaskAssignment.Where(ta => ta.User_ID == id);
                _context.tblTaskAssignment.RemoveRange(assignments);

                // Remove Ratings (where they are either the Rater or the Ratee)
                var ratings = _context.tblRating.Where(r => r.Rater_ID == id || r.Ratee_ID == id);
                _context.tblRating.RemoveRange(ratings);

                // Remove Notification Receipts
                var notifications = _context.tblNotificationRecipient.Where(nr => nr.User_ID == id);
                _context.tblNotificationRecipient.RemoveRange(notifications);

                // Remove Group Messages
                var messages = _context.tblGroupMessage.Where(m => m.Sender_ID == id);
                _context.tblGroupMessage.RemoveRange(messages);

                // Remove Group Memberships
                var memberships = _context.tblGroupMember.Where(gm => gm.User_ID == id);
                _context.tblGroupMember.RemoveRange(memberships);

                // 3. Delete the actual User account record
                _context.tblUser.Remove(user);

                // Save all changes and commit transaction atomically
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return NoContent(); // 204 Success
            }
            catch (Exception ex)
            {
                // If any delete operation fails, roll back everything to protect database state
                await transaction.RollbackAsync();
                return StatusCode(500, $"An error occurred during account cleanup: {ex.Message}");
            }
        }

        // Helper method to completely dissolve an empty group when no users remain
        private async System.Threading.Tasks.Task PurgeGroupEntirelyAsync(int groupId)
        {
            // Remove remaining assignments associated with this group's tasks
            var taskIds = _context.tblTask.Where(t => t.Group_ID == groupId).Select(t => t.Task_ID);
            _context.tblTaskAssignment.RemoveRange(_context.tblTaskAssignment.Where(ta => taskIds.Contains(ta.Task_ID)));

            _context.tblTask.RemoveRange(_context.tblTask.Where(t => t.Group_ID == groupId));
            _context.tblRating.RemoveRange(_context.tblRating.Where(r => r.Group_ID == groupId));
            _context.tblMeeting.RemoveRange(_context.tblMeeting.Where(m => m.Group_ID == groupId));
            _context.tblGroupMessage.RemoveRange(_context.tblGroupMessage.Where(m => m.Group_ID == groupId));

            // Clear notifications and recipients
            var notificationIds = _context.tblGroupNotification.Where(gn => gn.Group_ID == groupId).Select(gn => gn.Group_Notification_ID);
            _context.tblNotificationRecipient.RemoveRange(_context.tblNotificationRecipient.Where(nr => notificationIds.Contains(nr.Group_Notification_ID)));
            _context.tblGroupNotification.RemoveRange(_context.tblGroupNotification.Where(gn => gn.Group_ID == groupId));

            _context.tblGroupMember.RemoveRange(_context.tblGroupMember.Where(gm => gm.Group_ID == groupId));

            var group = await _context.tblGroup.FindAsync(groupId);
            if (group != null)
            {
                _context.tblGroup.Remove(group);
            }
        }

        // Helper method to check if a user exists by ID
        private bool UserExists(int id)
        {
            return _context.tblUser.Any(equals => equals.User_ID == id);
        }
    }
}
