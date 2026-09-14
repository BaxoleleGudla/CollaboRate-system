using CollaboRateAPIServer.Hubs;
using CollaboRateAPIServer.Models; 
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CollaboRateAPIServer.Interceptors
{
    public class NotificationInterceptor : SaveChangesInterceptor
    {
        private readonly IHubContext<NotificationHub> _notificationHub;
        private List<PendingNotification> _pendingNotifications = new();

        public NotificationInterceptor(IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }

        private class PendingNotification
        {
            public int RecipientId { get; set; }
            public int UserId { get; set; }
            public int GroupNotificationId { get; set; }
            public bool IsRead { get; set; }
        }

        // Step 1: Detect newly added recipient rows BEFORE saving (while entity state is added)
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            _pendingNotifications = eventData.Context.ChangeTracker.Entries<NotificationRecipient>()
                .Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                .Select(e => new PendingNotification
                {
                    RecipientId = e.Entity.Notification_Recipient_ID,
                    UserId = e.Entity.User_ID,
                    GroupNotificationId = e.Entity.Group_Notification_ID,
                    IsRead = e.Entity.Is_Read
                })
                .ToList();

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        // Step 2: Broadcast via SignalR after the database transaction commits successfully
        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            if (_pendingNotifications.Any() && eventData.Context != null)
            {
                var notificationIds = _pendingNotifications.Select(n => n.GroupNotificationId).Distinct().ToList();

                // Load the notification details asynchronously using EF Core's ToDictionaryAsync
                var groupNotifications = await eventData.Context.Set<GroupNotification>()
                    .Where(gn => notificationIds.Contains(gn.Group_Notification_ID))
                    .ToDictionaryAsync(gn => gn.Group_Notification_ID, cancellationToken);

                foreach (var pending in _pendingNotifications)
                {
                    if (groupNotifications.TryGetValue(pending.GroupNotificationId, out var notif))
                    {
                        // Broadcasts objects containing very property required by frontend NotificationDto
                        await _notificationHub.Clients
                            .Group($"User_{pending.UserId}")
                            .SendAsync("ReceiveNotification", new
                            {
                                RecipientID = pending.RecipientId,
                                Type = notif.Notification_Type,
                                Message = notif.Notification_Message,
                                Created_At = notif.Created_At,
                                IsRead = pending.IsRead
                            }, cancellationToken);
                    }
                }

                _pendingNotifications.Clear();
            }

            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
