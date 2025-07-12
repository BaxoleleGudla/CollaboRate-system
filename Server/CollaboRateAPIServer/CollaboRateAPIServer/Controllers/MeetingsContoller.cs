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
    public class MeetingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeetingsController(AppDbContext context)
        {
            _context = context;
        }

        // Method to get meetings for a group
        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetMeetingsByGroup(int groupId, [FromQuery] string? keyword = null)
        {
            try
            {
                // Base query filtered by Group_ID
                var query = _context.tblMeeting
                    .Where(m => m.Group_ID == groupId);

                // Apply keword filter if provied
                if (string.IsNullOrWhiteSpace(keyword) == false)
                {
                    string lowerKeyword = keyword.ToLower();
                    query = query.Where(m =>
                        m.Meeting_Title.ToLower().Contains(lowerKeyword) ||
                        (m.Meeting_Description != null && m.Meeting_Description.ToLower().Contains(lowerKeyword)));
                }

                var meetings = await query
                    .OrderBy(m => m.Meeting_Date)
                    .Select(m => new MeetingDto
                    {
                        Meeting_ID = m.Meeting_ID,
                        Meeting_Title = m.Meeting_Title,
                        Meeting_Description = m.Meeting_Description,
                        Meeting_Date = m.Meeting_Date
                    })
                    .ToListAsync();

                if (meetings == null || !meetings.Any())
                {
                    return NotFound("No meetings found for Group ID " + groupId + ".");
                }

                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while processing your request.");
            }
        }
    }
}
