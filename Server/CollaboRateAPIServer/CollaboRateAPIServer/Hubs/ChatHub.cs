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

        // Clients call this to start receiving updates for a specific group
        public async Task SubscribeToGroupUpdates(int groupId)
        {
            string groupName = $"Group_Admin_Room_{groupId}";
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        // Clients call this when they leave the screen to stop receiving updates
        public async Task UnsubscribeFromGroupUpdates(int groupId)
        {
            string groupName = $"Group_Admin_Room_{groupId}";
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
