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
using Microsoft.AspNetCore.SignalR;
using CollaboRateAPIServer.Hubs;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupMessagesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _chatHub;

        public GroupMessagesController(AppDbContext context, IHubContext<ChatHub> chatHub)
        {
            _context = context;
            _chatHub = chatHub;
        }

        // Method to get all messages
        [HttpGet("messages")]
        public async Task<IActionResult> GetMessagesAsync([FromQuery] int groupId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50, [FromQuery] string keyword = null)
        {
            if (groupId <= 0)
            {
                return BadRequest(new { error = "Invalid Group ID." });
            }

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1 || pageSize > 100)
            {
                pageSize = 50; // limit max page size for perfomance
            }

            try
            {
                var messagesQuery = from m in _context.tblGroupMessage
                                    join u in _context.tblUser on m.Sender_ID equals u.User_ID
                                    where m.Group_ID == groupId
                                    select new MessageDto
                                    {
                                        Message_ID = m.Message_ID,
                                        Group_ID = m.Group_ID,
                                        Message_Text = m.Message_Text,
                                        Created_At = m.Created_At,
                                        SenderUsername = u.Username
                                    };

                // Apply search filter if keyword is not null or empty
                if (!string.IsNullOrEmpty(keyword))
                {
                    messagesQuery = messagesQuery.Where(m => m.Message_Text.ToLower().Contains(keyword.ToLower()));
                }

                var totalMessages = await messagesQuery.CountAsync();

                var messages = await messagesQuery
                    .OrderByDescending(m => m.Created_At)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var result = new
                {
                    TotalCount = totalMessages,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Messages = messages.OrderBy(m => m.Created_At) // Return messages ascending for UI display
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while retrieving messages.", detail = ex.Message });
            }
        }

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

                // Load sender username for boradcast if not included in new message
                var sender = await _context.tblUser.FirstOrDefaultAsync(u => u.User_ID == newMessage.Sender_ID);
                var senderUsername = sender?.Username ?? "Unknown";

                // Broadcast the new message to all clients via signal R
                await _chatHub.Clients.All.SendAsync("ReceiveMessage", senderUsername, newMessage.Message_Text, newMessage.Created_At);

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
