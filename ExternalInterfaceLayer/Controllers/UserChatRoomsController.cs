using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.UserChatRooms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatRoomsController : ControllerBase
    {
        private readonly IUserChatRoomsService _userChatRoomsService;

        public UserChatRoomsController(IUserChatRoomsService userChatRoomsService)
        {
            _userChatRoomsService = userChatRoomsService;
        }

        [HttpGet]
        [Route("GetAllInformationAsync")]
        public async Task<IActionResult> GetAll()
        {
            var userChatRooms = await _userChatRoomsService.GetAllInformationAsync();
            return Ok(userChatRooms);
        }

        [HttpGet]
        [Route("GetAllActiveInformationAsync")]
        public async Task<IActionResult> GetAllActive()
        {
            var userChatRooms = await _userChatRoomsService.GetAllActiveInformationAsync();
            return Ok(userChatRooms);
        }

        [HttpGet("GetInformationByID/{IDUser}/{IDChatRoom}")]
        public async Task<IActionResult> GetInformationByID(string IDUser, Guid IDChatRoom)
        {
            var userChatRoom = await _userChatRoomsService.GetInformationByID(IDUser, IDChatRoom);
            if (userChatRoom == null)
                return NotFound("User chat room not found.");
            else
                return Ok(userChatRoom);
        }

        [HttpPost]
        [Route("CreateUserChatRooms")]
        public async Task<IActionResult> CreateUserChatRooms(UserChatRoomsCreateVM request)
        {
            var result = await _userChatRoomsService.CreateAsync(request);
            if (result)
                return Ok("User chat room created successfully.");
            else
                return BadRequest("Failed to create user chat room.");
        }

        [HttpDelete]
        [Route("RemoveUserChatRoomsAsync/{IDUser}/{IDChatRoom}/{IDUserDelete}")]
        public async Task<IActionResult> RemoveUserChatRoomsAsync(string IDUser, Guid IDChatRoom, Guid IDUserDelete)
        {
            var result = await _userChatRoomsService.RemoveAsync(IDUser, IDChatRoom, IDUserDelete);
            if (result)
                return Ok("User chat room removed successfully.");
            else
                return BadRequest("Failed to remove user chat room.");
        }

        [HttpPut]
        [Route("UpdateUserChatRoomsAsync/{IDUser}/{IDChatRoom}")]
        public async Task<IActionResult> UpdateUserChatRoomsAsync(string IDUser, Guid IDChatRoom, UserChatRoomsUpdateVM request)
        {
            var result = await _userChatRoomsService.UpdateAsync(IDUser, IDChatRoom, request);
            if (result)
                return Ok("User chat room updated successfully.");
            else
                return BadRequest("Failed to update user chat room.");
        }
    }
}
