using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Business.Services
{
    public class MessageService : IMessageService
    {
        private IMessageRepo _messageRepo;
        private IConversationService _conversationService;
        public MessageService(IMessageRepo messageRepo)
        {
            _messageRepo = messageRepo;
        }
        public Message SendMessage(Message message)
        {
           // Check if there is a direct conversation already exist between the two users.
           // If yes, take the conversationId and put it in the message
           // If not, create the conversation, add the participants
           return _messageRepo.SendMessage(message);
        }
    }
}
