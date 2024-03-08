using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }   
        public string Tag { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }
}
