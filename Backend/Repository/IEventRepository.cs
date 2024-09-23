using Backend.Models;

namespace Backend.Repository
{
    public interface IEventRepository
    {
        Task<List<MatchEvent>> GetAllEventsAsync();
        Task<List<MatchEvent>> GetEventsByMatchIdAsync(string matchId);
        Task<MatchEvent> CreateEventAsync(MatchEvent matchEvent);
        Task<bool> DeleteEventAsync(string eventId);
    }
}
