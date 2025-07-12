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
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        /*// Start fixing this method
        // Method to get all tasks
        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByGroup(int groupId, [FromQuery] string? keyword = null)
        {
            // Base query filtered by Group_ID
            IQueryable<Models.Task> query = _context.tblTask.Where(t => t.Group_ID == groupId);

            query = query.Include(t => t.TaskAssignments)
                         .ThenInclude(ta => ta.User);

            // Apply search filter if keyword is provided
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string lowerKeyword = keyword.ToLower();
                query = query.Where(t =>
                    t.Task_Title.ToLower().Contains(lowerKeyword) ||
                    (t.Task_Description != null && t.Task_Description.ToLower().Contains(lowerKeyword))
                );
            }

            // Materialized query to memory
            var taskEntities = await query.ToListAsync();

            if (taskEntities == null || !taskEntities.Any())
            {
                return NotFound("No tasks found for Group ID " + groupId + " with the given search criteria.");
            }

            var tasks = await query
                .Select(t => new TaskDto
                {
                    Task_ID = t.Task_ID,
                    Task_Title = t.Task_Title,
                    Task_Description = t.Task_Description,
                    Deadline = t.Deadline,
                    AssignedUsers = t.TaskAssignments.Select(ta => ta.User.Username).ToList(),
                    IsCompleted = t.TaskAssignments.All(ta => ta.Is_Completed),
                    Status = GetTaskStatus(t.TaskAssignments)
                })
                .ToListAsync();

            return Ok(tasks);
        }

        // Method to get task status
        private string GetTaskStatus(ICollection<TaskAssignment> assignments)
        {
            if (assignments == null || !assignments.Any())
                return "No Assignments";

            if (assignments.All(a => a.Is_Completed))
                return "Completed";

            if (assignments.Any(a => a.Is_Completed))
                return "In Progress";

            return "Not Started";
        }*/
    }
}

