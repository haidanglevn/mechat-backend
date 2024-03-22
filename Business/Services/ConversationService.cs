using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Business.Services
{
    public class ConversationService : IConversationService
    {
        private IConversationRepo _conversationRepo;
        private IMapper _mapper;
        private IParticipantService _participantService;  
        public ConversationService(IConversationRepo conversationRepo, IParticipantService participant, IMapper mapper)
        {
            _conversationRepo = conversationRepo;
            _participantService = participant;  
            _mapper = mapper;
        }

        public Conversation CreateNewConversation(ConversationCreateDTO conversationCreateDTO)
        {
            // First check if the direct conversation is already exist!
            if (conversationCreateDTO.ConversationType == ConversationType.Direct && _conversationRepo.HasDirectConversation(conversationCreateDTO.UserId1,conversationCreateDTO.UserId2))
            {
                throw new Exception("Direct Conversation is already exist!");
            }

            try
            {
                Conversation newConversation = new Conversation()
                {
                    ConversationType = conversationCreateDTO.ConversationType,
                    Title = conversationCreateDTO.Title,
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                };
                //Participant participant1 = new()
                //{
                //    ConversationId = newConversation.Id,
                //    UserId = conversationCreateDTO.UserId1,
                //};
                
                //Participant participant2 = new()
                //{
                //    ConversationId = newConversation.Id,
                //    UserId = conversationCreateDTO.UserId2,
                //};
                //_participantService.AddParticipant(participant1);
                //_participantService.AddParticipant(participant2);

                return _conversationRepo.CreateNewConversation(newConversation, conversationCreateDTO.UserId1, conversationCreateDTO.UserId2);

            }
            catch (Exception ex) 
            {
                throw new Exception("Error creating conversation");
            }
        }

        public ConversationReadDTO? GetAllMessagesByConversationId(Guid conversationId)
        {
            var cons = _conversationRepo.GetAllMessagesByConversationId(conversationId);
            if (cons is not null)
            {
                return _mapper.Map<Conversation, ConversationReadDTO>(cons);
            }
            else
            {
                return null;
            }
        }

        public Conversation GetDirectConversation(ConversationCheckHasDirectDTO checkDTO)
        {
            return _conversationRepo.GetDirectConversation(checkDTO.UserId1,checkDTO.UserId2);
        }

        public bool HasDirectConversation(ConversationCheckHasDirectDTO checkDTO)
        {
            return _conversationRepo.HasDirectConversation(checkDTO.UserId1, checkDTO.UserId2);
        }
    }
}
