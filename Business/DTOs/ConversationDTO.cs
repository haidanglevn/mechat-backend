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
}
