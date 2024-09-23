using Backend.Models;

namespace Backend.Repository
{
    public interface IMatchRepository
    {
        Task<List<Match>> GetAllMatchesAsync();
        Task<Match> GetMatchByIdAsync(string matchId);
        Task<Match> CreateMatchAsync(Match match);
        Task<Match> UpdateMatchAsync(Match match);
        Task<bool> DeleteMatchAsync(string matchId);
    }
}
