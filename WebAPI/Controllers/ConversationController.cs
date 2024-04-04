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

        [HttpGet("get-conversation-info/{conversationId}")]
        public ActionResult<ConversationInfoDTO> GetConversationInfo(Guid conversationId)
        {
            return Ok(_conversationService.GetConversationInfo(conversationId));
        }  
        
        [HttpGet("get-messages-for-conversation/{conversationId}")]
        public ActionResult<MessageGetAllDTO> GetMessagesForConversation(Guid conversationId)
        {
            return Ok(_conversationService.GetMessagesForConversation(conversationId));
        }

        [HttpGet("get-all-conversation/{userId}")]
        public ActionResult<IEnumerable<ConversationInfoDTO>> GetAllConversations(Guid userId) 
        {
            return Ok(_conversationService.GetAllUserConversations(userId));
        }
    }
}
