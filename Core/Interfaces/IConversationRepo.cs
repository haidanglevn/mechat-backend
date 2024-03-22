using Core.Entities;

namespace Core.Interfaces
{
    public interface IConversationRepo
    {
        Conversation CreateNewConversation(Conversation conversation, Guid userId1, Guid userId2);
        Conversation? GetAllMessagesByConversationId(Guid conversationId);
        bool HasDirectConversation(Guid userId1, Guid userId2);
        Conversation GetDirectConversation(Guid userId1, Guid userId2);
    }
}
