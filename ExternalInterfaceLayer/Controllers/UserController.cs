using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.User;
using DataAccessLayer.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
