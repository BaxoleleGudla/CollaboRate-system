using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CollaboRateAPIServer.Hubs
{
    public class EvaluationsHub : Hub
    {
        // Clients call this to receive evaluation updates
        public async Task JoinEvaluationRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        // Clients call this when closing the form or switching groups
        public async Task LeaveEvaluationRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
