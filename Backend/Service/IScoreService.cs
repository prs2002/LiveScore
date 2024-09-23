using Backend.Models;

namespace Backend.Service
{
    public interface IScoreService
    {
        Task<List<Score>> GetAllAsync();
        Task<List<Score>> GetScoresByMatchIdAsync(string matchId);
        Task<Score> CreateScoreAsync(Score score);
        Task<bool> UpdateScoreAsync(Score score);
        Task<bool> DeleteScoreAsync(string scoreId);
    }
}
