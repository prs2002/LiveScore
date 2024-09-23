namespace Backend.Repository
{
    using Backend.Models;
    using MongoDB.Driver;

    public class MatchRepository : IMatchRepository
    {
        private readonly IMongoCollection<Match> _matches;

        public MatchRepository(IMongoDatabase database)
        {
            _matches = database.GetCollection<Match>("matches");
        }

        public async Task<List<Match>> GetAllMatchesAsync() => await _matches.Find(_ => true).ToListAsync();
        public async Task<Match> GetMatchByIdAsync(string matchId) => await _matches.Find(m => m.MatchID == matchId).FirstOrDefaultAsync();
        public async Task<Match> CreateMatchAsync(Match match) { await _matches.InsertOneAsync(match); return match; }
        public async Task<Match> UpdateMatchAsync(Match match) { await _matches.ReplaceOneAsync(m => m.MatchID == match.MatchID, match); return match; }
        public async Task<bool> DeleteMatchAsync(string matchId) { var result = await _matches.DeleteOneAsync(m => m.MatchID == matchId); return result.DeletedCount > 0; }
    }

}
