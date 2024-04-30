using BusinessLogicLayer.Services.Implement;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Messages;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _IMessagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _IMessagesService = messagesService;
        }

        [HttpPost("send-to-user")]
        public async Task<IActionResult> SendMessageToUser([FromForm] MessagesCreateVM request)
        {
            try
            {
                await _IMessagesService.SendMessageToUser(request.IDSender, request.IDReceiver, request);
                return Ok("Message sent to user successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("send-to-group")]
        public async Task<IActionResult> SendMessageToGroup([FromForm] MessagesCreateVM request, string CodeChatRooms)
        {
            try
            {
                await _IMessagesService.SendMessageToGroup(request.IDSender, CodeChatRooms, request);
                return Ok("Message sent to group successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("between-users")]
        public async Task<ActionResult<List<MessagesVM>>> GetMessagesBetweenUsers(string IDSender, string IDReceiver)
        {
            var messages = await _IMessagesService.GetMessagesBetweenUsers(IDSender, IDReceiver);
            return Ok(messages);
        }

        [HttpGet("for-group")]
        public async Task<ActionResult<List<MessagesVM>>> GetMessagesForGroup(string CodeChatRooms)
        {
            var messages = await _IMessagesService.GetMessagesForGroup(CodeChatRooms);
            return Ok(messages);
        }

        [HttpGet("for-user")]
        public async Task<ActionResult<List<MessagesVM>>> GetMessagesForUser(string IDUser)
        {
            var messages = await _IMessagesService.GetMessagesForUser(IDUser);
            return Ok(messages);
        }

        [HttpGet("from-user-to-group")]
        public async Task<ActionResult<List<MessagesVM>>> GetMessagesFromUserToGroup(string IDSender, string CodeChatRooms)
        {
            var messages = await _IMessagesService.GetMessagesFromUserToGroup(IDSender, CodeChatRooms);
            return Ok(messages);
        }

    }
}
