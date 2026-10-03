using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CollaboRateAPIServer.Hubs
{
    public class ProjectGroupHub : Hub
    {
        // Allows clients to join a specific group room for targeted updates
		public async Task JoinGroupRoom(string groupName)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
		}

		// Allows clients to leave a group room when switching or closing
		public async Task LeaveGroupRoom(string groupName)
		{
			await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
		}
    }
}
