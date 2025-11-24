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
    }
}
