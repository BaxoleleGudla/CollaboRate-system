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
