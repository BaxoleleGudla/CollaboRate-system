using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Dtos;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificationsController(AppDbContext context)
        {
            _context = context;
        }
		
		// Method to count unread notifications
		[HttpGet("unread-count/user/{userId}/group/{groupId}")]
		public async Task<IActionResult> GetUserCount(int userId, int groupId)
		{
            if (userId <= 0 || groupId <= 0)
            {
                return BadRequest(new { message = "Invalid User ID or Group ID provided." });
            }

            try
            {
                // Join tblNotificationRecipient with tblGroupNotification to check unread items for this user and group
                int unreadCount = await (
                    from r in _context.tblNotificationRecipient
                    join g in _context.tblGroupNotification
                        on r.Group_Notification_ID equals g.Group_Notification_ID
                    where r.User_ID == userId
                       && g.Group_ID == groupId
                       && !r.Is_Read
                    select r
                ).CountAsync();

                return Ok(new
                {
                    unreadCount = unreadCount,
                    hasUnread = unreadCount > 0
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while counting unread notifications." });
            }
        }
		
        // GET: api/Notifications/user/5/group/2
        [HttpGet("user/{userId}/group/{groupId}")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetNotifications(int userId, int groupId)
        {
            var notifications = await (from nr in _context.tblNotificationRecipient
                                       join gn in _context.tblGroupNotification on nr.Group_Notification_ID equals gn.Group_Notification_ID
                                       where nr.User_ID == userId && gn.Group_ID == groupId
                                       orderby gn.Created_At descending
                                       select new NotificationDto
                                       {
                                           RecipientID = nr.Notification_Recipient_ID,
                                           Type = gn.Notification_Type,
                                           Message = gn.Notification_Message,
                                           Created_At = gn.Created_At,
                                           IsRead = nr.Is_Read
                                       }).ToListAsync();

            return Ok(notifications);
        }

        // PUT: api/Notifications/mark-all-read/user/5/group/2
        [HttpPut("mark-all-read/user/{userId}/group/{groupId}")]
        public async Task<IActionResult> MarkAllAsRead(int userId, int groupId)
        {
            // Find all unread records for this user in this specific group
            var unreadNotifications = await _context.tblNotificationRecipient
                .Where(nr => nr.User_ID == userId && !nr.Is_Read &&
                             _context.tblGroupNotification
                                .Any(gn => gn.Group_Notification_ID == nr.Group_Notification_ID && gn.Group_ID == groupId))
                .ToListAsync();

            if (unreadNotifications.Any())
            {
                foreach (var notif in unreadNotifications)
                {
                    notif.Is_Read = true;
                }
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
