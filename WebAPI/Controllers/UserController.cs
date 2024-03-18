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
        private readonly IChatHub _chatHub;
        public UserController(IUserService userService, IChatHub chatHub)
        {
            _userService = userService; 
            _chatHub = chatHub; 
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

        [HttpPost("signalR")]
        public async Task SendSignalR([FromBody] string? message = null)
        {
           await  _chatHub.SendMessage(string.IsNullOrEmpty(message) ? "Emnpty Message" : message);
        }
    }
}
