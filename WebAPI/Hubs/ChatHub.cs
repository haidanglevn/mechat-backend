using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class ChatHub: Hub
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
        }

        public async Task LeaveConversation(Guid conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
        }

        public async Task Typing(string username, Guid conversationId)
        {
            await Clients.OthersInGroup(conversationId.ToString()).SendAsync("Typing", username, conversationId);
        }

        public async Task StopTyping(string username, Guid conversationId)
        {
            await Clients.OthersInGroup(conversationId.ToString()).SendAsync("StopTyping", username, conversationId);
        }

    }
}
