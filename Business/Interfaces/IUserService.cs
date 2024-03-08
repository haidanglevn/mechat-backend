using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserReadDTO> GetAllUsers(GetAllParams options);
        UserReadDTO? GetOneUser(Guid userId);
        UserReadDTO CreateNewUser(UserCreateDTO user);
        bool CheckMail(string mail);
    }
}
