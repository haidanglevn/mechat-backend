using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class MessageSentDTO
    {
        public string Content { get; set; }
        public string? Title { get; set; } = string.Empty;
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; } // Needed when conversation is not created yet.
        public Guid? ConversationId { get; set; } // This can be null if the conversation is not created yet

    }
}
