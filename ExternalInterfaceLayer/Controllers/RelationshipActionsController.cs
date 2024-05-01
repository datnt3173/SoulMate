using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.RelationshipAction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipActionsController : ControllerBase
    {
        private readonly IRelationshipActionService _relationshipActionService;
        private readonly IMapper _mapper;

        public RelationshipActionsController(IRelationshipActionService relationshipActionService, IMapper mapper)
        {
            _relationshipActionService = relationshipActionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllRelationshipActions")]
        public async Task<IActionResult> GetAllRelationshipActions()
        {
            var relationshipActions = await _relationshipActionService.GetAllRelationshipActionsAsync();
            return Ok(relationshipActions);
        }

        [HttpGet("GetRelationshipActionByID/{ID}")]
        public async Task<IActionResult> GetRelationshipActionByID(Guid ID)
        {
            var relationshipAction = await _relationshipActionService.GetRelationshipActionByIDAsync(ID);
            if (relationshipAction == null)
                return NotFound("Relationship action not found.");
            return Ok(relationshipAction);
        }

        [HttpPost]
        [Route("CreateRelationshipAction")]
        public async Task<IActionResult> CreateRelationshipAction(RelationshipActionCreateVM relationshipActionCreateVM)
        {
            var result = await _relationshipActionService.CreateRelationshipActionAsync(relationshipActionCreateVM);
            if (result)
                return Ok("Relationship action created successfully.");
            return BadRequest("Failed to create relationship action.");
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateRelationshipAction(Guid id, RelationshipActionUpdateVM relationshipActionUpdateVM)
        //{
        //    var result = await _relationshipActionService.UpdateRelationshipActionAsync(id, relationshipActionUpdateVM);
        //    if (result)
        //        return Ok("Relationship action updated successfully.");
        //    return BadRequest("Failed to update relationship action.");
        //}

        [HttpDelete("DeleteRelationshipAction/{ID}")]
        public async Task<IActionResult> DeleteRelationshipAction(Guid ID)
        {
            var result = await _relationshipActionService.DeleteRelationshipActionAsync(ID);
            if (result)
                return Ok("Relationship action deleted successfully.");
            return BadRequest("Failed to delete relationship action.");
        }
    }
}
