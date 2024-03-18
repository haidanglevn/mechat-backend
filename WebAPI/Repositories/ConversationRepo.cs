﻿using Core.Entities;
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

        public IEnumerable<Conversation> GetAllMessagesByConversationId(Guid conversationId)
        {
            throw new NotImplementedException();
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
    }
}
