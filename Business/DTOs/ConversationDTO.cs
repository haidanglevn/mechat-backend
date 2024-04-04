using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs
{
    public class ConversationCreateDTO
    {
        public string Title { get; set; }
        public ConversationType ConversationType { get; set; }
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
    }

    public class ConversationCheckHasDirectDTO
    {
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
    }

    public class ConversationInfoDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ConversationType ConversationType { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public MessageSimpleDTO? LastMessage { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
