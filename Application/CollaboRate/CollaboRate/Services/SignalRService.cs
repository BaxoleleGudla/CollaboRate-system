using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using CollaboRate.Dtos;
using Microsoft.Toolkit.Uwp.Notifications;

namespace CollaboRate.Services
{
    public class SignalRService
    {
        private static SignalRService _instance;
        public static SignalRService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SignalRService();
                }
                return _instance;
            }
        }

        private HubConnection _hubConnection;
        public event Action<NotificationDto> OnNotificationReceived;

        public async Task InitializeAsync(int userId)
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
                return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://collaborateapi.runasp.net/notificationHub")
                .WithAutomaticReconnect()
                .Build();

            // Wire up the Toas Notification Handler
            OnNotificationReceived -= HandleIncomingNotification;
            OnNotificationReceived += HandleIncomingNotification;

            // Listen for the broadcast sent by NotificationInterceptor
            _hubConnection.On<NotificationDto>("ReceiveNotification", (notification) =>
            {
                OnNotificationReceived?.Invoke(notification);
            });

            try
            {
                await _hubConnection.StartAsync();

                // Join the user's specific SignalR group on the server
                await _hubConnection.InvokeAsync("JoinUserGroup", userId);
            }
            catch (Exception ex)
            {
                // Handle or log connection failures silently
                System.Diagnostics.Debug.WriteLine($"SignalR Connection Error: {ex.Message}");
            }
        }

        // Evaluates notification type and triggers windows toasts
        private void HandleIncomingNotification(NotificationDto notification)
        {
            if (notification == null)
            {
                return;
            }

            if (UserSettings.Enable_Push_Notifications != false)
            {
                // Match notification types
                string type = notification.Type?.ToLower() ?? "";
                string message = notification.Message ?? "";

                switch (type)
                {
                    case "meeting scheduled":
                        NotificationService.ShowNewMeetingNotification(type, message);
                        break;
                    case "meeting updated":
                        NotificationService.ShowMeetingUpdatedNotification(type, message);
                        break;
                    case "meeting cancelled":
                        NotificationService.ShowMeetingCancelledNotification(message);
                        break;
                    case "membership accepted":
                    case "membership rejected":
                    case "membership removed":
                    case "join request":
                    case "member requested":
                        NotificationService.ShowJoinRequestNotification(message);
                        break;
                    case "task deleted":
                        NotificationService.ShowTaskDeletedNotification(message);
                        break;
                    // Default fallback
                    default:
                        NotificationService.ShowNewMeetingNotification(string.IsNullOrEmpty(type) ? "Notification" : type, message);
                        break;
                }
            }
        }

        public async Task StopAsync(int userId)
        {
            if (_hubConnection != null)
            {
                if (_hubConnection.State == HubConnectionState.Connected)
                {
                    await _hubConnection.InvokeAsync("LeaveUserGroup", userId);
                    await _hubConnection.StopAsync();
                }
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
            }
        }
    }
}
