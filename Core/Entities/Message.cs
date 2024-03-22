using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Message: BaseEntity
    {
        public string Content { get; set; }
        public string? Title { get; set; } = string.Empty;  
        public Guid SenderId { get; set; }
        public Guid ConversationId { get; set; }

        public User Sender { get; set; }
        public Conversation Conversation { get; set; }
    }
}
