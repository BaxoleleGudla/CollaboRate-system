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
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Method to update the username and password
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateDto)
        {
            if (id <= 0 || updateDto == null)
            {
                return BadRequest(new { error = "Invalid user ID or update data." });
            }

            if (id != updateDto.User_ID)
            {
                return BadRequest(new { error = "User ID mismatch." });
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
                    message = "User updated successfully.",
                    user = new {
                        id = user.User_ID,
                        username = user.Username,
                        email = user.Email
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while updating account details.", detail = ex.Message });
            }
        }
    }
}
