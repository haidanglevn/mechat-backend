using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Participant
    {
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }
        public string? NickName { get; set; } = null;
        public DateTime JoinDate { get; set; } = DateTime.Now;
        //public User User { get; set; }
        //public Conversation Conversation { get; set; }
    }
}
