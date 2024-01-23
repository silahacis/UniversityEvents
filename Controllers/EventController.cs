using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityEvents.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityEvents.Controllers
{
    [ApiController]
    [Route("/")]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            if (!_dbContext.Events.Any(e => e.Id == 1))
            {
                var mockEvent1 = new Event
                {
                    Id = 1,
                    Name = "Event 1",
                    Description = "Description 1"
                };
                _dbContext.Events.Add(mockEvent1);
            }

            if (!_dbContext.Events.Any(e => e.Id == 2))
            {
                var mockEvent2 = new Event
                {
                    Id = 2,
                    Name = "Event 2",
                    Description = "Description 2"
                };
                _dbContext.Events.Add(mockEvent2);
            }

            _dbContext.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> Get()
        {
            var @events = await _dbContext.Events.ToListAsync();
            return Ok(@events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetById(int id)
        {
            var @event = await _dbContext.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound("Event Not Found");
            }
            return Ok(@event);
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> Post(Event @event)
        {
            if (_dbContext.Events.Any(e => e.Id == @event.Id))
            {
                return BadRequest("Event with the same ID already exists.");
            }
            _dbContext.Events.Add(@event);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Events.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> Put(int id, Event updatedEvent)
        {
            var existingEvent = await _dbContext.Events.FindAsync(id);
            if (existingEvent == null)
            {
                return NotFound("Event Not Found");
            }

            existingEvent.Name = updatedEvent.Name;
            existingEvent.Description = updatedEvent.Description;

            await _dbContext.SaveChangesAsync();

            return Ok(existingEvent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Event>>> Delete(int id)
        {
            var @event = await _dbContext.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound("Event Not Found");
            }

            _dbContext.Events.Remove(@event);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Events.ToListAsync());
        }
    }
}

