using Business.DTOs;
using Business.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ConversationController : ControllerBase
    {
        private IConversationService _conversationService;
        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }
        [HttpPost("/create")]
        public IActionResult CreateConversation([FromBody] ConversationCreateDTO conversationCreateDTO)
        {
            return CreatedAtAction(nameof(CreateConversation), _conversationService.CreateNewConversation(conversationCreateDTO));
        }

        [HttpPost("/checkDirect")] 
        public bool HasDirectConversation([FromBody] ConversationCheckHasDirectDTO checkDto)
        {
            return _conversationService.HasDirectConversation(checkDto);    
        }

    }
}
