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
    public class GroupMessagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupMessagesController(AppDbContext context)
        {
            _context = context;
        }

        // Method to get all messages


        // Method to add a message
        [HttpPost("messages")]
        public async Task<IActionResult> AddMessageAsync([FromBody] GroupMessage newMessage)
        {
            if (newMessage == null || newMessage.Sender_ID <= 0 || newMessage.Group_ID <= 0 || string.IsNullOrWhiteSpace(newMessage.Message_Text))
            {
                return BadRequest("Invalid message data.");
            }

            try
            {
                await _context.tblGroupMessage.AddAsync(newMessage);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMessageById), new { id = newMessage.Message_ID }, newMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the message: {ex.Message}");
            }
        }

        // Method to get a message by ID
        [HttpGet("messages/{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _context.tblGroupMessage.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }
    }
}
