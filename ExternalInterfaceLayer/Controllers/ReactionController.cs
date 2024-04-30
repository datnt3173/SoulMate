using BusinessLogicLayer.Services.Implement;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Reaction;
using DataAccessLayer.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _IReactionService;

        public ReactionController(IReactionService reactionService)
        {
            _IReactionService = reactionService;
        }
        [HttpGet]
        [Route("GetAllInformationReactionAsync")]
        public async Task<ActionResult<List<ReactionVM>>> GetAllInformationReactionAsync()
        {
            var reactions = await _IReactionService.GetAllInformationAsync();
            return Ok(reactions);
        } 
        
        [HttpGet]
        [Route("GetAllActiveInformationReactionAsync")]
        public async Task<ActionResult<List<ReactionVM>>> GetAllActiveInformationReactionAsync()
        {
            var reactions = await _IReactionService.GetAllActiveInformationAsync();
            return Ok(reactions);
        }

        [HttpGet("GetInformationByReactionID/{ID}")]
        public async Task<ActionResult<ReactionVM>> GetInformationByReactionID(Guid ID)
        {
            var reaction = await _IReactionService.GetInformationByID(ID);
            if (reaction == null)
            {
                return NotFound();
            }
            return Ok(reaction);
        }

        [HttpPost]
        [Route("CreateReaction")]
        public async Task<ActionResult<bool>> CreateReaction([FromForm]ReactionCreateVM reactionCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _IReactionService.CreateAsync(reactionCreateVM);
            if (!success)
            {
                return StatusCode(500, "Failed to create reaction.");
            }
            return Ok(true);
        }

        [HttpDelete("DeleteReaction/{ID}")]
        public async Task<ActionResult<bool>> DeleteReaction(Guid ID)
        {
            var success = await _IReactionService.RemoveAsync(ID);
            if (!success)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPut("UpdateReaction/{ID}")]
        public async Task<ActionResult<bool>> UpdateReaction(Guid ID, EnumBase.ReactionType newType)
        {
            var success = await _IReactionService.UpdateAsync(ID, newType);
            if (!success)
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
