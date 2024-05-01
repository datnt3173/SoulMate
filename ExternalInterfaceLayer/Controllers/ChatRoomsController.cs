using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.ChatRooms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomsController : ControllerBase
    {
        private readonly IChatRoomsService _chatRoomsService;

        public ChatRoomsController(IChatRoomsService chatRoomsService)
        {
            _chatRoomsService = chatRoomsService;
        }

        [HttpPost]
        [Route("CreateChatRooms")]
        public async Task<IActionResult> Create(ChatRoomsCreateVM request)
        {
            var result = await _chatRoomsService.CreateAsync(request);
            if (result)
                return Ok("Chat room created successfully.");
            else
                return BadRequest("Failed to create chat room.");
        }

        [HttpGet]
        [Route("GetAllInformationChatRoomsAsync")]
        public async Task<IActionResult> GetAllInformationChatRoomsAsync()
        {
            var chatRooms = await _chatRoomsService.GetAllInformationAsync();
            return Ok(chatRooms);
        }

        [HttpGet]
        [Route("GetInformationChatRoomsByID/{ID}")]
        public async Task<IActionResult> GetInformationChatRoomsByID(Guid ID)
        {
            var chatRoom = await _chatRoomsService.GetInformationByID(ID);
            if (chatRoom == null)
                return NotFound("Chat room not found.");
            else
                return Ok(chatRoom);
        }

        [HttpPut]
        [Route("UpdateChatRoomsAsync/{ID}")]

        public async Task<IActionResult> UpdateChatRoomsAsync(Guid ID, ChatRoomsUpdateVM request)
        {
            var result = await _chatRoomsService.UpdateAsync(ID, request);
            if (result)
                return Ok("Chat room updated successfully.");
            else
                return BadRequest("Failed to update chat room.");
        }

        [HttpDelete]
        [Route("RemoveChatRoomsAsync/{ID}/{IDUserDelete}")]

        public async Task<IActionResult> RemoveChatRoomsAsync(Guid ID, string IDUserDelete)
        {
            var result = await _chatRoomsService.RemoveAsync(ID, IDUserDelete);
            if (result)
                return Ok("Chat room deleted successfully.");
            else
                return BadRequest("Failed to delete chat room.");
        }
    }
}
