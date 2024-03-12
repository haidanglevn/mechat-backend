using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Friendship: BaseEntity
    {
        public Guid RequestorId { get; set; }
        public User Requestor { get; set; }

        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; }
        public FriendshipStatus FriendshipStatus { get; set; }
    }

    public enum FriendshipStatus
    {
        Send = 0 , Accepted = 1, Denied = 2
    }
}
