using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Business.Services
{
    public class ConversationService : IConversationService
    {
        private IConversationRepo _conversationRepo;
        public ConversationService(IConversationRepo conversationRepo)
        {
            _conversationRepo = conversationRepo;
        }

        public Conversation CreateNewConversation(ConversationCreateDTO conversationCreateDTO)
        {
            Conversation newConversation = new Conversation()
            {
                ConversationType = conversationCreateDTO.ConversationType,
                Title = conversationCreateDTO.Title,
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
            };
            return _conversationRepo.CreateNewConversation(newConversation, conversationCreateDTO.UserId1, conversationCreateDTO.UserId2);
        }

        public IEnumerable<Conversation> GetAllMessagesByConversationId(Guid conversationId)
        {
            throw new NotImplementedException();
        }

        public bool HasDirectConversation(ConversationCheckHasDirectDTO checkDTO)
        {
            return _conversationRepo.HasDirectConversation(checkDTO.UserId1, checkDTO.UserId2);
        }
    }
}
