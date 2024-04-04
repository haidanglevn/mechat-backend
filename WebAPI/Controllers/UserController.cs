using Business.DTOs;
using Business.Interfaces;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Hubs;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("create-user")]
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = _userService.Login(userLoginDTO.Email, userLoginDTO.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _tokenService.CreateToken(user);
            var response = new { access_token = token };
            return Ok(response);
        }


    }
}
