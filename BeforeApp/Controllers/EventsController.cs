using BeforeApp.Domain.Models;
using BeforeApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<EventModel[]>> Get()
        {
            try
            {
                return await _eventService.GetAllEventsAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("byid/{id:int}")]
        public async Task<ActionResult<EventModel>> GetEventById(int id)
        {
            try
            {
                var result = await _eventService.GetEventByIdAsync(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<EventModel>> GetEventByMoniker(string moniker)
        {
            try
            {
                var result = await _eventService.GetEventByMonikerAsync(moniker);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<EventModel[]>> SearchByVarious(string name = null, string locationName = null,
            DateTime? dateTime = null,
            string locationCity = null, string music = null, string artist = null)
        {
            try
            {
                var results = await _eventService.GetEventsByParameters(name, dateTime, locationName, locationCity, music, artist);
                if (!results.Any()) return NotFound();
                return results;
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<ActionResult<EventModel>> AddEvent(EventModel model)
        {
            try
            {
                var existing = await _eventService.GetEventByMonikerAsync(model.Moniker);
                if (existing != null) return BadRequest("Moniker in use already!");

                if (await _eventService.Add(model) > 0)
                    return Created($"/api/events/{model.Moniker}", model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("byid/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var oldEvent = await _eventService.GetEventByIdAsync(id);
                if (oldEvent == null) return NotFound("Event not found");

                if (await _eventService.Delete(id)) return Ok("Deleted");

                return BadRequest("Not Able to delete");
            }
            catch (Exception)
            {
                return BadRequest("failed to delete");
            }
        }

        [HttpDelete("{moniker}")]
        public async Task<ActionResult> Delete(string moniker)
        {
            try
            {
                var oldEvent = await _eventService.GetEventByMonikerAsync(moniker);
                if (oldEvent == null) return NotFound("Event not found");

                if (await _eventService.Delete(moniker)) return Ok("Deleted");

                return BadRequest("Not Able to delete");
            }
            catch (Exception)
            {
                return BadRequest("failed to delete");
            }
        }

        [HttpPut("{moniker}")]
        public async Task<ActionResult<EventModel>> UpdateEvent(EventModel model, string moniker)
        {
            try
            {
                var id = await _eventService.GetIdByMonikerAsync(moniker);
                if (id <= 0) return NotFound($"Event with moniker {moniker} could not be found.");

                var updated = await _eventService.UpdateEntity(model, id);
                if (updated == null) return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");

                return updated;
            }
            catch (Exception)
            {
                return BadRequest("Pan błąd");
            }
        }
    }
}