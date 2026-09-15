using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Models;
using CollaboRateAPIServer.Dtos;

namespace CollaboRateAPIServer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserSettingsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public UserSettingsController(AppDbContext context)
		{
			_context = context;
		}

		// Method to get user settings
		[HttpGet("{userId}")]
		public async Task<IActionResult> GetSettings(int userId)
		{
			if (userId <= 0)
			{
				return BadRequest(new { message = "Invalid User ID provided." });
			}

			try
			{
				// Check if user exists
				bool userExists = await _context.tblUser.AnyAsync(u => u.User_ID == userId);
				if (!userExists)
				{
					return NotFound(new { message = $"User with ID {userId} does not exist." });
				}

				// Retrive settins, or return default preferences if none exist yet
				var settings = await _context.tblUserSettings.FindAsync(userId);

				var resultDto = new UserSettingsDto
				{
					Enable_Push_Notifications = settings?.Enable_Push_Notifications ?? true,
					Enable_Email_Notifications = settings?.Enable_Email_Notifications ?? true
				};

				return Ok(resultDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An internal server error occurred while processing your request." });
			}
		}

		// Method to update the user settings
		[HttpPut("{userId}")]
		public async Task<IActionResult> UpdateSettings(int userId, [FromBody] UserSettingsDto dto)
		{
			if (userId <= 0)
			{
				return BadRequest(new { message = "Invalid User ID provided." });
			}

			if (dto == null)
			{
				return BadRequest(new { message = "Request body cannot be empty." });
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				// Verify if user exists
				bool userExists = await _context.tblUser.AnyAsync(u => u.User_ID == userId);
				if (!userExists)
				{
					return NotFound(new { message = $"User with ID {userId} does not exist." });
				}

				var settings = await _context.tblUserSettings.FindAsync(userId);

				if (settings == null)
				{
					// Create new settings
					settings = new UserSetting
					{
						User_ID = userId,
						Enable_Push_Notifications = dto.Enable_Push_Notifications,
						Enable_Email_Notifications = dto.Enable_Email_Notifications,
						Updated_At = DateTime.UtcNow
					};

					_context.tblUserSettings.Add(settings);
				}
				else
				{
					// Update existing settings record
					settings.Enable_Push_Notifications = dto.Enable_Push_Notifications;
					settings.Enable_Email_Notifications = dto.Enable_Email_Notifications;
					settings.Updated_At = DateTime.UtcNow;

					_context.tblUserSettings.Update(settings);
				}

				await _context.SaveChangesAsync();

				return Ok(new { message = "User settings updated successfully." });
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return Conflict(new { message = "The settings were modified by another request. Please try again." });
			}
			catch (DbUpdateException ex)
			{
				return StatusCode(500, new { message = "A database error occurred while persisting settings." });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An internal server error occurred while processing your request." });
			}
		}
	}
}
