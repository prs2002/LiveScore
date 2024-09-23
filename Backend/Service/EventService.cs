using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public Task<List<MatchEvent>> GetAllAsync()
        {
            return _eventRepository.GetAllEventsAsync();
        }
        public async Task<List<MatchEvent>> GetEventsByMatchIdAsync(string matchId) => await _eventRepository.GetEventsByMatchIdAsync(matchId);

        public async Task<MatchEvent> CreateEventAsync(MatchEvent matchEvent) => await _eventRepository.CreateEventAsync(matchEvent);

        public async Task<bool> DeleteEventAsync(string eventId) => await _eventRepository.DeleteEventAsync(eventId);
    }
}
