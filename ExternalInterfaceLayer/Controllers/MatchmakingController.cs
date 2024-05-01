using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;

[Route("api/[controller]")]
[ApiController]
public class MatchmakingController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly MatchmakingAlgorithm _matchmakingAlgorithm;

    public MatchmakingController(UserManager<ApplicationUser> userManager, MatchmakingAlgorithm matchmakingAlgorithm)
    {
        _userManager = userManager;
        _matchmakingAlgorithm = matchmakingAlgorithm;
    }

    [HttpGet("GetMatches/{IDUser}")]
    public async Task<IActionResult> GetMatches(string IDUser)
    {
        try
        {
            var matchResults = await _matchmakingAlgorithm.GetMatchResults(IDUser);
            return Ok(matchResults);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
