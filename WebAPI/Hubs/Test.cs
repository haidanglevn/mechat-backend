using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class TestHub: Hub
    {
        public async Task SendMessageToConversation(string user, string message, Guid conversationId)
        {
            // Broadcasts the message to all clients listening to this specific conversation
            //await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessageInConversation", user, message, conversationId);
            await Clients.All.SendAsync("ReceiveMessageInConversation", user, message, conversationId);
        }

        public async Task JoinConversation(Guid conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
            await Clients.Caller.SendAsync("JoinedConversation", conversationId);
        }

        public async Task LeaveConversation(Guid conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
            await Clients.Caller.SendAsync("LeftConversation", conversationId);
        }
    }
}
