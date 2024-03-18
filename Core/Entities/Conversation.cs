using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Conversation: BaseEntity
    {
        public string Title { get; set; }
        public ConversationType ConversationType { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }

    public enum ConversationType
    {
        Direct, 
        Group
    }
}
