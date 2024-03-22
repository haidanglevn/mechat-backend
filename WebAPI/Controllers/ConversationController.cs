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
        [HttpPost("create-conversation")]
        public IActionResult CreateConversation([FromBody] ConversationCreateDTO conversationCreateDTO)
        {
            return CreatedAtAction(nameof(CreateConversation), _conversationService.CreateNewConversation(conversationCreateDTO));
        }

        [HttpPost("check-direct")] 
        public bool HasDirectConversation([FromBody] ConversationCheckHasDirectDTO checkDto)
        {
            return _conversationService.HasDirectConversation(checkDto);    
        }

        [HttpGet("get-messages-by-conversation-id/{conversationId}")]
        public ActionResult<ConversationReadDTO> GetAllMessagesByConversationId(Guid conversationId)
        {
            return Ok(_conversationService.GetAllMessagesByConversationId(conversationId));
        }

    }
}
