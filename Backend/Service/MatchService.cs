using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<List<Match>> GetAllMatchesAsync() => await _matchRepository.GetAllMatchesAsync();
        public async Task<Match> GetMatchByIdAsync(string matchId) => await _matchRepository.GetMatchByIdAsync(matchId);
        public async Task<Match> CreateMatchAsync(Match match) => await _matchRepository.CreateMatchAsync(match);
        public async Task<Match> UpdateMatchAsync(Match match) => await _matchRepository.UpdateMatchAsync(match);
        public async Task<bool> DeleteMatchAsync(string matchId) => await _matchRepository.DeleteMatchAsync(matchId);
    }
}
