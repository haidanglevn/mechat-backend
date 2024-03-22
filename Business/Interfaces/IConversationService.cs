using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IConversationService
    {
        Conversation CreateNewConversation(ConversationCreateDTO conversationCreateDTO);
        IEnumerable<Conversation> GetAllMessagesByConversationId(Guid conversationId);
        bool HasDirectConversation(ConversationCheckHasDirectDTO checkDTO);
        Conversation GetDirectConversation(ConversationCheckHasDirectDTO checkDTO);
    }
}
