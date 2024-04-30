using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.User;
using DataAccessLayer.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _IUserService;
        public UserController(IUserService userService)
        {
            _IUserService = userService;
        }

        [HttpGet("GetInformationUser/{ID}")]
        public async Task<ActionResult<UserVM>> GetInformationUser(string ID)
        {
            var user = await _IUserService.GetInformationByID(ID);

            if (user == null)
            {
                return NotFound(); // Trả về mã lỗi 404 nếu không tìm thấy người dùng
            }

            return Ok(user); // Trả về dữ liệu người dùng dưới dạng JSON
        }
        [HttpGet]
        [Route("GetAllInformationUserAsync")]
        public async Task<IActionResult> GetAllInformationUserAsync()
        {
            var objCollection = await _IUserService.GetAllInformationAsync();

            return Ok(objCollection);
        } 
        
        [HttpGet]
        [Route("GetAllActiveInformationUserAsync")]
        public async Task<IActionResult> GetAllActiveInformationUserAsync()
        {
            var objCollection = await _IUserService.GetAllActiveInformationAsync();

            return Ok(objCollection);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var response = await _IUserService.Login(model);

            if (!response.IsSuccess)
            {
                return Unauthorized(response.Message);
            }

            return Ok(new
            {
                token = response.Token,
                role = response.Roles.FirstOrDefault() // Sử dụng Roles từ phản hồi
            });
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
           
            var result = await _IUserService.RegisterAsync(registerUser, role);
            if (result.IsSuccess)
            {
                return Ok("Tạo tài khoản thành công");
            }
            else
            {
                return BadRequest("Có lỗi trong quá trình thực hiện.");
            }
        }
        [HttpDelete("{ID}/{IDUserDelete}")]
        public async Task<IActionResult> Remove(string ID, string IDUserDelete)
        {
            var success = await _IUserService.RemoveAsync(ID, IDUserDelete);
            if (success)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
