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
using Microsoft.Extensions.Options;

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

                return _conversationRepo.CreateNewConversation(newConversation, conversationCreateDTO.UserId1, conversationCreateDTO.UserId2);

            }
            catch
            {
                throw new Exception("Error creating conversation");
            }
        }
        public Conversation GetDirectConversation(ConversationCheckHasDirectDTO checkDTO)
        {
            return _conversationRepo.GetDirectConversation(checkDTO.UserId1,checkDTO.UserId2);
        }

        public ConversationInfoDTO? GetConversationInfo(Guid conversationId)
        {
            var conversation = _conversationRepo.GetConversationInfo(conversationId);
            if (conversation is not null)
            {
                // Map the conversation to DTO
                var conversationDto = _mapper.Map<Conversation, ConversationInfoDTO>(conversation);

                // Fetch and map the last message
                var lastMessage = _conversationRepo.GetLastMessage(conversationId);
                if (lastMessage != null)
                {
                    conversationDto.LastMessage = _mapper.Map<Message, MessageSimpleDTO>(lastMessage);
                }

                return conversationDto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<MessageGetAllDTO> GetMessagesForConversation(Guid conversationId)
        {
            var messages = _conversationRepo.GetMessagesForConversation(conversationId);
            return messages.Select(m => _mapper.Map<Message, MessageGetAllDTO>(m));
        }


        public bool HasDirectConversation(ConversationCheckHasDirectDTO checkDTO)
        {
            return _conversationRepo.HasDirectConversation(checkDTO.UserId1, checkDTO.UserId2);
        }

        public IEnumerable<ConversationInfoDTO> GetAllUserConversations(Guid userId)
        {
            // Fetch all conversations for the user
            var conversations = _conversationRepo.GetAllUserConversations(userId).ToList(); // Materialize Queries Early with ToList() to prevent NpgsqlOperationInProgressException

            var conversationDtos = new List<ConversationInfoDTO>();

            // Iterate over each conversation and map it to ConversationInfoDTO
            foreach (var conversation in conversations)
            {
                var conversationDto = _mapper.Map<Conversation, ConversationInfoDTO>(conversation);

                // Take the conversation id and get the last message.
                var lastMessage = _conversationRepo.GetLastMessage(conversation.Id);
                if (lastMessage != null)
                {
                    conversationDto.LastMessage = _mapper.Map<Message, MessageSimpleDTO>(lastMessage);
                }

                conversationDtos.Add(conversationDto);
            }

            return conversationDtos;
        }


    }
}
