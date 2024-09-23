using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }
        public Task<List<Score>> GetAllAsync()
        {
            return _scoreRepository.GetAllScoresAsync();
        }
        public async Task<List<Score>> GetScoresByMatchIdAsync(string matchId) => await _scoreRepository.GetScoresByMatchIdAsync(matchId);

        public async Task<Score> CreateScoreAsync(Score score) => await _scoreRepository.CreateScoreAsync(score);

        public async Task<bool> UpdateScoreAsync(Score score) => await _scoreRepository.UpdateScoreAsync(score);

        public async Task<bool> DeleteScoreAsync(string scoreId) => await _scoreRepository.DeleteScoreAsync(scoreId);
    }
}
