using Backend.Models;
using MongoDB.Driver;

namespace Backend.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<MatchEvent> _events;

        public EventRepository(IMongoDatabase database)
        {
            _events = database.GetCollection<MatchEvent>("events");
        }
        public async Task<List<MatchEvent>> GetAllEventsAsync()
        {
            return await _events.Find(e => true).ToListAsync();
        }

        public async Task<List<MatchEvent>> GetEventsByMatchIdAsync(string matchId) => await _events.Find(e => e.MatchID == matchId).ToListAsync();
        public async Task<MatchEvent> CreateEventAsync(MatchEvent matchEvent) { await _events.InsertOneAsync(matchEvent); return matchEvent; }
        public async Task<bool> DeleteEventAsync(string eventId) { var result = await _events.DeleteOneAsync(e => e.EventID == eventId); return result.DeletedCount > 0; }
    }
}
