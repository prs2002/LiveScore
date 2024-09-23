using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }
        [HttpGet("match/{matchId}")]
        public async Task<IActionResult> GetEventsByMatchId(string matchId)
        {
            var events = await _eventService.GetEventsByMatchIdAsync(matchId);
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] MatchEvent matchEvent)
        {
            var createdEvent = await _eventService.CreateEventAsync(matchEvent);
            return CreatedAtAction(nameof(GetEventsByMatchId), new { matchId = createdEvent.MatchID }, createdEvent);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(string eventId)
        {
            var deleted = await _eventService.DeleteEventAsync(eventId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
