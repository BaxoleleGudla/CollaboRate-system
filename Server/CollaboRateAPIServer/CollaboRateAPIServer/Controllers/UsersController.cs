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

        // POST: api/users
        // Adds a new user to the database
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.tblUser.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.User_ID }, user);
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
                return NotFound();
            }

            _context.tblUser.Remove(user);
            await _context.SaveChangesAsync();

            // 204 No Content means delete successful
            return NoContent();
        }

        // Helper method to check if a user exists by ID
        private bool UserExists(int id)
        {
            return _context.tblUser.Any(equals => equals.User_ID == id);
        }
    }
}
