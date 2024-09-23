using Backend.Models;

namespace Backend.Repository
{
    public interface IScoreRepository
    {
        Task<List<Score>> GetAllScoresAsync();
        Task<List<Score>> GetScoresByMatchIdAsync(string matchId);
        Task<Score> CreateScoreAsync(Score score);
        Task<bool> UpdateScoreAsync(Score score);
        Task<bool> DeleteScoreAsync(string scoreId);
    }
}
