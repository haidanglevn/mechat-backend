using Core.Entities;

namespace Core.Interfaces
{
    public interface IConversationRepo
    {
        Conversation CreateNewConversation(Conversation conversation, Guid userId1, Guid userId2);
        IEnumerable<Conversation> GetAllMessagesByConversationId(Guid conversationId);
        bool HasDirectConversation(Guid userId1, Guid userId2);
    }
}
