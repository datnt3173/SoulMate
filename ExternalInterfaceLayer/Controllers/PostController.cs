using BusinessLogicLayer.Services.Implement;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Post;
using BusinessLogicLayer.Viewmodels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _IPostService;
        public PostController(IPostService IPostService)
        {
            _IPostService = IPostService;
        }
        [HttpPost]
        [Route("CreatePostAsync")]
        public async Task<IActionResult> CreatePostAsync([FromForm] PostCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _IPostService.CreateAsync(model);
            if (!result)
            {
                return BadRequest(new { Message = "Error creating Post" });
            }

            return Ok(new { Message = "Post created successfully" });
        }
        [HttpGet("GetInformationPost/{ID}")]
        public async Task<ActionResult<UserVM>> GetInformationPost(Guid ID)
        {
            var user = await _IPostService.GetInformationByID(ID);

            if (user == null)
            {
                return NotFound(); 
            }

            return Ok(user);
        }
        [HttpGet]
        [Route("GetAllInformationPostAsync")]
        public async Task<IActionResult> GetAllInformationPostAsync()
        {
            var objCollection = await _IPostService.GetAllInformationAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("GetAllActiveInformationPostAsync")]
        public async Task<IActionResult> GetAllActiveInformationPostAsync()
        {
            var objCollection = await _IPostService.GetAllActiveInformationAsync();

            return Ok(objCollection);
        }
        [HttpPut("ChangeVisibility/{ID}")]
        public async Task<IActionResult> ChangeVisibility(Guid ID, [FromForm] PostVisibility request)
        {
            try
            {
                var result = await _IPostService.ChangeVisibilityAsync(ID, request);

                if (result)
                {
                    return Ok(); 
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
