using Microsoft.AspNetCore.SignalR;

namespace CollaboRateAPIServer.Hubs
{
    public class ProjectGroupHub : Hub
    {
        public async Task SubscribeToGroupUpdates(int groupId)
        {
            string groupName = $"Group_Admin_Room_{groupId}";
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task UnsubscribeFromGroupUpdates(int groupId)
        {
            string groupName = $"Group_Admin_Room_{groupId}";
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Group_{groupId}");
        }
    }
}
