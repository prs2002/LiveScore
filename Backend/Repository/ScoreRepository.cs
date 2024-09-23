using Backend.Models;
using MongoDB.Driver;

namespace Backend.Repository
{
    // Score Repository
    public class ScoreRepository : IScoreRepository
    {
        private readonly IMongoCollection<Score> _scores;

        public ScoreRepository(IMongoDatabase database)
        {
            _scores = database.GetCollection<Score>("scores");
        }

        public async Task<List<Score>> GetScoresByMatchIdAsync(string matchId) => await _scores.Find(s => s.MatchID == matchId).ToListAsync();
        public async Task<Score> CreateScoreAsync(Score score) { await _scores.InsertOneAsync(score); return score; }
        public async Task<bool> UpdateScoreAsync(Score score) { var result = await _scores.ReplaceOneAsync(s => s.ScoreID == score.ScoreID, score); return result.ModifiedCount > 0; }
        public async Task<bool> DeleteScoreAsync(string scoreId) { var result = await _scores.DeleteOneAsync(s => s.ScoreID == scoreId); return result.DeletedCount > 0; }
        public async Task<List<Score>> GetAllScoresAsync()
        {
            return await _scores.Find(score => true).ToListAsync();
        }
    }
}
