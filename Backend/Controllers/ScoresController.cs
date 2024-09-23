using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllScores()
        {
            var scores = await _scoreService.GetAllAsync();
            return Ok(scores);
        }

        [HttpGet("match/{matchId}")]
        public async Task<IActionResult> GetScoresByMatchId(string matchId)
        {
            var scores = await _scoreService.GetScoresByMatchIdAsync(matchId);
            return Ok(scores);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScore([FromBody] Score score)
        {
            var createdScore = await _scoreService.CreateScoreAsync(score);
            return CreatedAtAction(nameof(GetScoresByMatchId), new { matchId = createdScore.MatchID }, createdScore);
        }

        [HttpPut("{scoreId}")]
        public async Task<IActionResult> UpdateScore(string scoreId, [FromBody] Score score)
        {
            if (scoreId != score.ScoreID) return BadRequest();
            var updated = await _scoreService.UpdateScoreAsync(score);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{scoreId}")]
        public async Task<IActionResult> DeleteScore(string scoreId)
        {
            var deleted = await _scoreService.DeleteScoreAsync(scoreId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
