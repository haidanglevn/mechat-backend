using Business.DTOs;
using Business.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class MessageController : ControllerBase
    {
       private IMessageService _messageService;
       public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("send-message")]
        public IActionResult SendMessage(MessageSentDTO messageDto)
        {
            return CreatedAtAction(nameof(SendMessage), _messageService.SendMessage(messageDto));
        }
    }
}
