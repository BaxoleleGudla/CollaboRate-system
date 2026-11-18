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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CollaboRateAPIServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Method to update the username and email
        [HttpPut("users")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateDto)
        {
            // Extract authenticated User ID from JWT token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized("Invalid token claims.");
            }

            if (id <= 0 || updateDto == null)
            {
                return BadRequest(new { error = "Invalid user ID or update data." });
            }

            try
            {
                // Find the user
                var user = await _context.tblUser.FindAsync(id);

                if (user == null)
                {
                    return NotFound(new { error = "User not found." });
                }

                // Check if username already exists (excluding current user)
                if (!string.IsNullOrEmpty(updateDto.Username) && updateDto.Username != user.Username)
                {
                    var usernameExists = await _context.tblUser.AnyAsync(u => u.Username == updateDto.Username && u.User_ID != id);

                    if (usernameExists)
                    {
                        return BadRequest(new { error = "Username already exists." });
                    }
                    user.Username = updateDto.Username;
                }

                // Check if email already exists (excluding current user)
                if (!string.IsNullOrEmpty(updateDto.Email) && updateDto.Email != user.Email)
                {
                    var emailExists = await _context.tblUser.AnyAsync(u => u.Email == updateDto.Email && u.User_ID != id);

                    if (emailExists)
                    {
                        return BadRequest(new { error = "Email already exists." });
                    }
                    user.Email = updateDto.Email;
                }

                // Update username and password
                _context.tblUser.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new {
                    message = "User updated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while updating account details.", detail = ex.Message });
            }
        }

        // Method to update a password
        [HttpPut("users/password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto passwordDto)
        {
            // Extract authenticated User ID from JWT token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized("Invalid token claims.");
            }

            if (id <= 0 || passwordDto == null)
            {
                return BadRequest("Invalid user ID or password data.");
            }

            // Validate new password matches confirmation
            if (passwordDto.NewPassword != passwordDto.ConfirmPassword)
            {
                return BadRequest("New password and confirmation do not match.");
            }

            try
            {
                // Find the user
                var user = await _context.tblUser.FindAsync(id);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Verify current password
                if (user.PasswordHash != passwordDto.CurrentPassword)
                {
                    return BadRequest("Current password is incorrect.");
                }

                // Update password
                user.PasswordHash = passwordDto.NewPassword;

                _context.tblUser.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Password updated successfully.", userId = user.User_ID
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while updating the password.", detail = ex.Message });
            }
        }
    }
}
