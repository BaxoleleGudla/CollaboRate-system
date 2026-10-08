using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CollaboRateAPIServer.Hubs
{
    public class MeetingsHub : Hub
    {
        // Clients call this to receive updates
        public async Task JoinMeetingRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        // Clients call this when closing the form or switching groups
        public async Task LeaveMeetingRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
