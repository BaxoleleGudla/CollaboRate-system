using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CollaboRateAPIServer.Hubs
{
    public class NotificationHub : Hub
    {
        // Add connected user to their personal user group
        public async Task JoinUserGroup(int userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
        }

        // Leave personal group when signing out or switching accounts
        public async Task LeaveUserGroup(int userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
        }
    }
}