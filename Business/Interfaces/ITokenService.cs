using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;

namespace Business.Interfaces
{
    public interface ITokenService
    {   
        public string CreateToken(UserReadDTO userReadDTO);
    }
}
