using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserReadDTO> CreateUser(UserCreateDTO userCreateDTO) 
        {
            return CreatedAtAction(nameof(CreateUser), _userService.CreateNewUser(userCreateDTO));
        }

        [HttpPost("is-available")]
        public bool CheckMail([FromBody] string mail)
        {
            var isEmailExist = _userService.CheckMail(mail);
            return !isEmailExist;
        }

        
    }
}
