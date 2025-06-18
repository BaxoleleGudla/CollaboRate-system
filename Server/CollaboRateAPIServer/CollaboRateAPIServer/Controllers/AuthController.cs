using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;

namespace CollaboRateAPIServer.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/auth/login
        // This code authenticates a user by username and password
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // Find user by username
            var user = await _context.tblUser.FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            if (user.PasswordHash != loginRequest.Password)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Authentication successful
            return Ok(new { user.User_ID, user.Username, user.Email  });
        }

        // DTO class for login request payload
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
