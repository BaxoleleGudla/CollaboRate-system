using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Cryptography;

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

            // Generate a Refresh Token
            string refreshToken = GenerateSecureToken();
            user.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();

            // Authentication successful
            return Ok(new
            {
                user_ID = user.User_ID,
                usename = user.Username,
                email = user.Email,
                refreshToken = refreshToken
            });
        }

        // Method responsible for refresh token
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (request == null || request.UserId <= 0 || string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest("Invalid client request.");
            }

            var user = await _context.tblUser.FirstOrDefaultAsync(u => u.User_ID == request.UserId);

            // Validate that user exists and current token matches database
            if (user == null || user.RefreshToken != request.RefreshToken)
            {
                return Unauthorized("Invalid or expired refresh token.");
            }

            // Rotate the Refresh Token
            string newRefreshToken = GenerateSecureToken();
            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                user_ID = user.User_ID,
                username = user.Username,
                email = user.Email,
                refreshToken = newRefreshToken
            });
        }

        public static string GenerateSecureToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        // DTO class for login request payload
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class RefreshTokenRequest
        {
            public int UserId { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}
