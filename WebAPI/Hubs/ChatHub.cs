using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;

namespace WebAPI.Hubs
{
    public class ChatHub: Hub, IChatHub
    {
        //private readonly DatabaseContext _databaseContext;
        //private DbSet<Message> _messages;

        //public ChatHub(DatabaseContext databaseContext)
        //{
        //    _databaseContext = databaseContext;
        //    _messages = databaseContext.Messages;
        //}

        public ChatHub()
        {
        }


        //public async Task SendMessage(Guid senderId, Guid conversationId, string content)
        //{
        //    var message = new Message
        //    {
        //        Id = Guid.NewGuid(),
        //        SenderId = senderId,
        //        ConversationId = conversationId,
        //        Content = content,
        //        CreatedAt = DateTime.UtcNow
        //    };

        //    _databaseContext.Messages.Add(message);
        //    await _databaseContext.SaveChangesAsync();

        //    // Retrieve the conversation type
        //    Conversation? conversation = await _databaseContext.Conversations.FindAsync(conversationId);
        //    if (conversation == null)
        //    {
        //        // Handle the case where the conversation doesn't exist
        //        return;
        //    }

        //    // Check if the conversation is a direct message or group message
        //    if (conversation.ConversationType == ConversationType.Direct)
        //    {
        //        // This is a direct message
        //        // Logic for handling a direct message, e.g., notifying the recipient
        //        // Assuming the recipient is connected and we know their connection ID or user ID
        //        Participant recipient = conversation.Participants.FirstOrDefault(p => p.Id != senderId);
        //        await Clients.User(conversation.Participants.ToString()).SendAsync("ReceiveMessage", message);
        //    }
        //    else if (conversation.ConversationType == ConversationType.Group)
        //    {
        //        // This is a group message
        //        // Logic for handling a group message, e.g., notifying all participants
        //        // In a group message, you would typically add all users to a group with the name of the conversationId when they connect
        //        await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessage", message);
        //    }

        //    // Other conversation types can be handled similarly
        //}

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("foo", message ?? "hello world");
        }
    }
}
