using Microsoft.AspNetCore.Mvc;
using Backend.Service;
using Backend.Models;
using Amazon.Runtime.Internal;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            return Ok(matches);
        }

        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetMatchById(string matchId)
        {
            var match = await _matchService.GetMatchByIdAsync(matchId);
            if (match == null) return NotFound();
            return Ok(match);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] Match match)
        {
            var createdMatch = await _matchService.CreateMatchAsync(match);
            return Ok(createdMatch);
        }

        [HttpPut("{matchId}")]
        public async Task<IActionResult> UpdateMatch(string matchId, [FromBody] Match match)
        {
            if (matchId != match.MatchID) return BadRequest();
            var updatedMatch = await _matchService.UpdateMatchAsync(match);
            if (updatedMatch == null) return NotFound();
            return Ok(updatedMatch);
        }

        [HttpDelete("{matchId}")]
        public async Task<IActionResult> DeleteMatch(string matchId)
        {
            var deleted = await _matchService.DeleteMatchAsync(matchId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
