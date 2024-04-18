using Business.DTOs;
using Business.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class MessageController : ControllerBase
    {
       private IMessageService _messageService;
       private IHubContext<TestHub> _hubContext;
       public MessageController(IMessageService messageService, IHubContext<TestHub> hubContext)
        {
            _messageService = messageService;
            _hubContext = hubContext;
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(MessageSentDTO messageDto)
        {
            var result = _messageService.SendMessage(messageDto);
            //if (messageDto.ConversationId.HasValue)
            //{
            //    //await _hubContext.Clients.Group(messageDto.ConversationId.ToString())
            //    //         .SendAsync("ReceiveMessageInConversation", messageDto.SenderId, messageDto.Content, messageDto.ConversationId);
                
            //}
            await _hubContext.Clients.All.SendAsync("ReceiveMessageInConversation", messageDto.SenderId, messageDto.Content, messageDto.ConversationId);
            return CreatedAtAction(nameof(SendMessage), result);
        }
    }
}
