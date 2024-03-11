using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Business.Interfaces;
using Core.Entities;

namespace Business.Services
{
    public class UserService : IUserService
    {
        public bool CheckMail(string mail)
        {
            throw new NotImplementedException();
        }

        public UserReadDTO CreateNewUser(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserReadDTO> GetAllUsers(GetAllParams options)
        {
            throw new NotImplementedException();
        }

        public UserReadDTO? GetOneUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserReadDTO? Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
