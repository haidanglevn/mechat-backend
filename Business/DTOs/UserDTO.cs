using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }

    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }
}
