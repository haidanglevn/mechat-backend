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

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            return CreatedAtAction(nameof(SendMessage), _messageService.SendMessage(message));
        }
    }
}
