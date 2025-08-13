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

        // Method to get all tasks
        [HttpGet("tasks/by-group")]
        public async Task<ActionResult<List<TaskWithUsersDto>>> GetTasksByGroupAsync([FromQuery] int group_ID, [FromQuery] int? user_ID = null, [FromQuery] string? keyword = null)
        {
            // Base query
            var tasksQuery = _context.tblTask
                .Where(t => t.Group_ID == group_ID);

            // If a user_ID filter is provided, filter tasks to those assigned to that user
            if (user_ID.HasValue)
            {
                tasksQuery = tasksQuery
                    .Where(task => _context.tblTaskAssignment
                        .Any(ta => ta.Task_ID == task.Task_ID && ta.User_ID == user_ID.Value));
            }

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                string lowerKeyword = keyword.ToLower();

                tasksQuery = tasksQuery.Where(t =>
                    t.Task_Title.ToLower().Contains(lowerKeyword) || (t.Task_Description != null && t.Task_Description.ToLower().Contains(lowerKeyword)));
            }

            // Fetch tasks matching filters
            var tasks = await tasksQuery
                .OrderBy(tasks => tasks.Deadline)
                .ToListAsync();

            var taskIds = tasks.Select(t => t.Task_ID).ToList();

            // Fetch all assignmets for tasks
            var assignments = await _context.tblTaskAssignment
                .Where(ta => taskIds.Contains(ta.Task_ID))
                .Include(taskIds => taskIds.User)
                .ToListAsync();

            var assignmentsGrouped = assignments
                .GroupBy(taskIds => taskIds.Task_ID)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Build result DTOs
            var result = tasks.Select(task =>
            {
                assignmentsGrouped.TryGetValue(task.Task_ID, out var taskAssignments);

                // Assigned user names
                var assignedUserNames = taskAssignments?.Select(a => a.User?.Username ?? "Unkown User").ToList() ?? new List<string>();

                // Determine  task status
                bool isCompleted = taskAssignments != null && taskAssignments.Any() && taskAssignments.All(a => a.Is_Completed);

                return new TaskWithUsersDto
                {
                    Task_ID = task.Task_ID,
                    Task_Title = task.Task_Title,
                    Task_Description = task.Task_Description,
                    Deadline = task.Deadline.Date,
                    AssignedUserNames = assignedUserNames,
                    Status = isCompleted ? "Completed" : "Not Completed"
                };
            }).ToList();

            return Ok(result);
        }

        // Method to add a task
        [HttpPost("tasks")]
        public async Task<ActionResult> AddTaskAsync([FromBody] CreateTaskDto taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("Task data is required.");
            }

            if (string.IsNullOrEmpty(taskDto.Task_Title))
            {
                return BadRequest("Task Title is required.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var taskEntity = new Models.Task
                {
                    Group_ID = taskDto.Group_ID,
                    Task_Title = taskDto.Task_Title,
                    Task_Description = taskDto.Task_Description,
                    Deadline = taskDto.Deadline,
                    Created_At = DateTime.UtcNow
                };

                // Add task record
                await _context.tblTask.AddAsync(taskEntity);
                await _context.SaveChangesAsync();

                // Assign users
                if (taskDto.AssignedUserIds != null && taskDto.AssignedUserIds.Any())
                {
                    var taskAssignments = taskDto.AssignedUserIds.Select(userId => new TaskAssignment
                    {
                        Task_ID = taskEntity.Task_ID,
                        User_ID = userId,
                        Is_Completed = false,
                    });

                    await _context.tblTaskAssignment.AddRangeAsync(taskAssignments);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return Ok(new { Message = "Task created successfully.", TaksId = taskEntity.Task_ID });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                //return StatusCode(500, "An error occurred while adding the task." + ex.Message);

                // Unwrap inner exceptions to get detailed error message
                string errorMessage = ex.Message;
                Exception? inner = ex.InnerException;
                while (inner != null)
                {
                    errorMessage += " --> " + inner.Message;
                    inner = inner.InnerException;
                }

                return StatusCode(500, $"An error occurred while adding the task. {errorMessage}");
            }
        }

        // Method to update a task
        [HttpPut("tasks/update")]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] UpdateTaskDto updateTaskDto)
        {
            if (updateTaskDto == null || updateTaskDto.Task_ID <= 0)
            {
                return BadRequest("Invalid task data.");
            }

            try
            {
                // Retrieve existing task with assignments
                var task = await _context.tblTask
                    .Include(t => t.TaskAssignments)
                    .FirstOrDefaultAsync(t => t.Task_ID == updateTaskDto.Task_ID);

                if (task == null)
                {
                    return NotFound($"Task with ID {updateTaskDto.Task_ID} not found.");
                }

                // Update task properties
                task.Task_Title = updateTaskDto.Task_Title;
                task.Task_Description = updateTaskDto.Task_Description;
                task.Deadline = updateTaskDto.Deadline;

                // Update task assignments if provided
                if (updateTaskDto.AssignedUserIds != null)
                {
                    var existingUserIds = task.TaskAssignments.Select(ta => ta.User_ID).ToList();

                    var toAdd = updateTaskDto.AssignedUserIds.Except(existingUserIds).ToList();
                    var toRemove = existingUserIds.Except(updateTaskDto.AssignedUserIds).ToList();

                    // Remove assignments for users no longer assigned
                    var assignmentsToRemove = task.TaskAssignments
                        .Where(ta => toRemove.Contains(ta.User_ID))
                        .ToList();

                    foreach (var assignment in assignmentsToRemove)
                    {
                        task.TaskAssignments.Remove(assignment);
                    }
                    _context.tblTaskAssignment.RemoveRange(assignmentsToRemove);

                    // Add new assignments
                    var assigmnetsToAdd = toAdd.Select(userId => new TaskAssignment
                    {
                        Task_ID = task.Task_ID,
                        User_ID = userId
                    }).ToList();

                    foreach (var assignmet in assigmnetsToAdd)
                    {
                        task.TaskAssignments.Add(assignmet);
                    }
                }

                await _context.SaveChangesAsync();

                // Bulk update Is_Completed and Completed_At
                await _context.tblTaskAssignment
                    .Where(ta => ta.Task_ID == task.Task_ID)
                    .ExecuteUpdateAsync(update => update
                        .SetProperty(ta => ta.Is_Completed, updateTaskDto.Is_Completed)
                        .SetProperty(ta => ta.Completed_At, updateTaskDto.Is_Completed ? (DateTime?)DateTime.UtcNow : null));

                return Ok("Task updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the task: {ex.Message}");
            }
        }

        // Method to change the status of a task
        [HttpPut("tasks/{taskId}/change-status")]
        public async Task<IActionResult> ChangeTaskStatusAsync(int taskId, [FromQuery] bool isCompleted)
        {
            try
            {
                // Check task exists
                var taskExists = await _context.tblTask.AnyAsync(t => t.Task_ID == taskId);

                if (taskExists == false)
                {
                    return NotFound($"Task with ID {taskId} not found.");
                }

                // Buld update all assignments of this task
                await _context.tblTaskAssignment
                    .Where(ta => ta.Task_ID == taskId)
                    .ExecuteUpdateAsync(update => update
                        .SetProperty(ta => ta.Is_Completed, isCompleted)
                        .SetProperty(ta => ta.Completed_At, isCompleted ? (DateTime?)DateTime.UtcNow : null)
                    );

                return Ok($"Task {taskId} marked as {(isCompleted ? "completed" : "not completed")}.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the task status: {ex.Message}");
            }
        }
    }
}

