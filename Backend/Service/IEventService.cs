using Backend.Models;

namespace Backend.Service
{
    public interface IEventService
    {
        Task<List<MatchEvent>> GetAllAsync();
        Task<List<MatchEvent>> GetEventsByMatchIdAsync(string matchId);
        Task<MatchEvent> CreateEventAsync(MatchEvent matchEvent);
        Task<bool> DeleteEventAsync(string eventId);
    }
}
