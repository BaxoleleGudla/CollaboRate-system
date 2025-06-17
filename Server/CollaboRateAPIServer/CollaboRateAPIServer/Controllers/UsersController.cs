using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Models;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.tblUser.ToListAsync();
        }

        // GET: api/users/5
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

        // PUT: api/users/5
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

        // DELETE: api/users/5
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
