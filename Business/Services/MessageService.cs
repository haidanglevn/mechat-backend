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
    public class MessageService : IMessageService
    {
        private IMessageRepo _messageRepo;
        private IConversationService _conversationService;
        public MessageService(IMessageRepo messageRepo, IConversationService conversationService)
        {
            _messageRepo = messageRepo;
            _conversationService = conversationService;
        }

        public Message? SendMessage(MessageSentDTO messageDTO)
        {
            // Easier way, assump conversationId is exact
            Message message = new()
            {
                Content = messageDTO.Content,
                ConversationId = messageDTO.ConversationId!.Value,
                SenderId = messageDTO.SenderId,
            };
            return _messageRepo.SendMessage(message);
        }
        //public Message? SendMessage(MessageSentDTO messageSentDto)
        //{
        //   // SentDTO has two optional props: ConversationId & ReceiverId, one of them has to be present in the request!
        //   if (messageSentDto.ConversationId == null && messageSentDto.ReceiverId==null) 
        //   {
        //        throw new ArgumentException("Missing either ConversationId or ReceiverId, one of them must be present!");
        //   }

        //   // Add validation if the two userIds are valid

        //   // If conversationId is there, add them to the Message and create it.
        //   else if (messageSentDto.ConversationId.HasValue)
        //    {
        //        Message message = new()
        //        {
        //            ConversationId = messageSentDto.ConversationId.Value,
        //            Content = messageSentDto.Content,
        //            SenderId = messageSentDto.SenderId,
        //            Title = messageSentDto.Title,
        //        };
        //        return _messageRepo.SendMessage(message);
        //    }

        //    // If ReceiverId is there, check direct conversation already exist between the two users
        //    else if (messageSentDto.ReceiverId.HasValue)
        //    {
        //        ConversationCheckHasDirectDTO dto = new() { UserId1 = messageSentDto.SenderId, UserId2 = messageSentDto.ReceiverId!.Value };
        //        Conversation directConversation = _conversationService.GetDirectConversation(dto);
        //        Message message = new()
        //        {
        //            ConversationId = directConversation.Id,
        //            Content = messageSentDto.Content,
        //            SenderId = messageSentDto.SenderId,
        //            Title = messageSentDto.Title,
        //        };
        //        return _messageRepo.SendMessage(message);
        //    }

        //    else
        //    {
        //        return null;
        //    }

        //}


    }
}
