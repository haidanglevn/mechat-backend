using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;

namespace WebAPI.Repositories
{
    public class ConversationRepo : IConversationRepo
    {
        private DbSet<Conversation> _conversations;
        private DbSet<Message> _messages;
        private DbSet<Participant> _participants;
        private DatabaseContext _database;
        public ConversationRepo(DatabaseContext database)
        {
            _database = database;
            _conversations = database.Conversations;
            _messages = database.Messages;
            _participants = database.Participants;
        }
        public Conversation CreateNewConversation(Conversation conversation, Guid userId1, Guid userId2)
        {
            // Create first the conversation to get the conversationId
            _conversations.Add(conversation);
            _database.SaveChanges(); // have to save changes to have id

            // Then create 2 participants with that cons_id
            Participant participant1 = new(){
                ConversationId = conversation.Id,
                UserId = userId1,
            };
            _participants.Add(participant1);
            Participant participant2 = new(){
                ConversationId = conversation.Id,
                UserId = userId2,
            };
            _participants.Add(participant2);
            _database.SaveChanges();

            return conversation;
        }
      

        public Conversation GetDirectConversation(Guid userId1, Guid userId2)
        {
            // First, find if there's a direct conversation between the two users
            var directConversation = _participants
                .Where(p1 => p1.UserId == userId1)
                .Join(_participants,
                    p1 => p1.ConversationId,
                    p2 => p2.ConversationId,
                    (p1, p2) => new { P1 = p1, P2 = p2 })
                .Where(joined => joined.P2.UserId == userId2 && joined.P1.ConversationId == joined.P2.ConversationId)
                .Select(joined => _conversations.FirstOrDefault(c => c.Id == joined.P1.ConversationId && c.ConversationType == ConversationType.Direct))
                .FirstOrDefault();

            // Check if a conversation was found
            if (directConversation != null)
            {
                return directConversation;
            }
            else
            {
                throw new InvalidOperationException("No direct conversation exists between the specified users.");
            }
        }
        public bool HasDirectConversation(Guid userId1, Guid userId2)
        {
            var directConversationExists = _participants
                            .Where(p1 => p1.UserId == userId1)
                            .Join(_participants,
                                p1 => p1.ConversationId,
                                p2 => p2.ConversationId,
                                (p1, p2) => new { P1 = p1, P2 = p2 })
                            .Any(joined => joined.P2.UserId == userId2 && joined.P1.ConversationId == joined.P2.ConversationId
                                           && _conversations.Any(c => c.Id == joined.P1.ConversationId && c.ConversationType == ConversationType.Direct));

            return directConversationExists;
        }

        public IEnumerable<Conversation> GetAllUserConversations(Guid userId)
        {
            return _conversations.AsNoTracking().Where(c => c.Participants.Any(p => p.UserId == userId)).Include(c => c.Participants);
        }

        public Conversation? GetConversationInfo(Guid conversationId)
        {
            return _conversations
                        .Include(c => c.Participants)
                        .FirstOrDefault(c => c.Id == conversationId);
        }

        public Message? GetLastMessage(Guid conversationId)
        {
            return _messages.AsNoTracking().Where(m => m.ConversationId == conversationId).OrderByDescending(m => m.CreatedAt).FirstOrDefault();
        }

        public IEnumerable<Message> GetMessagesForConversation(Guid conversationId)
        {
            return _messages.AsNoTracking().Where(m => m.ConversationId == conversationId).OrderBy(m => m.CreatedAt);
        }

    }
}
