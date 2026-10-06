using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CollaboRateAPIServer.Hubs
{
    public class TasksHub : Hub
    {
        // Clients call this to recived task update
        public async Task JoinTaskRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        // Clients call this when closing the form or switching groups
        public async Task LeaveTaskRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
