using Core.Entities;

namespace Core.Interfaces
{
    public interface IConversationRepo
    {
        Conversation CreateNewConversation(Conversation conversation, Guid userId1, Guid userId2);
        bool HasDirectConversation(Guid userId1, Guid userId2);
        Conversation GetDirectConversation(Guid userId1, Guid userId2);
        IEnumerable<Conversation> GetAllUserConversations(Guid userId);
        Conversation? GetConversationInfo(Guid conversationId);
        IEnumerable<Message> GetMessagesForConversation(Guid conversationId);
        Message? GetLastMessage(Guid conversationId);
    };
}
