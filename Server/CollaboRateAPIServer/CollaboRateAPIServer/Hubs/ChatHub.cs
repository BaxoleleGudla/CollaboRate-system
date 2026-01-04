using Microsoft.AspNetCore.SignalR;

namespace CollaboRateAPIServer.Hubs
{
    public class ChatHub : Hub
    {
        // Method server calls to send a message to all clients
        public async Task SendMessage(string senderUsername, string messageText, DateTime createdAt)
        {
            await Clients.All.SendAsync("ReceiveMessage", senderUsername, messageText, createdAt);
        }

        // Group admins join this group to get pending users updates
        public async Task JoinPendingRequestsGroup(int groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"PendingRequests_{groupId}");
        }

        public async Task LeavePendingRequestsGroup(int groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"PendingRequests_{groupId}");
        }
    }
}
