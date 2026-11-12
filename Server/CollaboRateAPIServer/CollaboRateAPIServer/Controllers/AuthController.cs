using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Models;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CollaboRateAPIServer.Controllers
{	
	[ApiController]
	[Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/auth/login
        // This code authenticates a user by username and password
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
			try
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

                // Generate JWT Token
                string jwtToken = GenerateJwtToken(user);

				// Generate a Refresh Token
				string refreshToken = GenerateSecureToken();
				user.RefreshToken = refreshToken;
				await _context.SaveChangesAsync();

                // Authentication successful
                return Ok(new AuthResponse
                {
                    User_ID = user.User_ID,
                    Username = user.Username,
                    Email = user.Email,
                    Token = jwtToken,
                    RefreshToken = refreshToken
                });
            }
			catch (Exception ex)
            {
                string innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, $"Database or EF error: {innerMsg}");
            }
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
            string newJwtToken = GenerateJwtToken(user);
            string newRefreshToken = GenerateSecureToken();
            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                User_ID = user.User_ID,
                Username = user.Username,
                Email = user.Email,
                Token = newJwtToken,
                RefreshToken = newRefreshToken
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("Jwt:SecretKey is missing.");
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.User_ID.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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

        public class AuthResponse
        {
            public int User_ID { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}
