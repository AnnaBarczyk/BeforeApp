﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BeforeApp.Data.Services;
using BeforeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                return await _eventService.GetAll();
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
                var result = await _eventService.GetEventByAsync(id);
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
                var result = await _eventService.GetEventByAsync(moniker);
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
                var existing = await _repository.GetEventByMonikerAsync(model.Moniker);
                if (existing != null) return BadRequest("Moniker in use already!");

                _eventService.Add(model);

                // wersja bez services --> bezpośrednio w kontrolerze
                //var newEvent = _mapper.Map<Event>(model);
                //_repository.Add(newEvent);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/events/{model.Moniker}", _mapper.Map<EventModel>(model));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var oldEvent = await _repository.GetById(id);
                if (oldEvent == null) return NotFound("Event not found");

                _repository.Delete(id);

                if (await _repository.SaveChangesAsync()) return Ok("Deleted");

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
                var old = await _eventService.GetByAsync(moniker);
                if (old == null) return NotFound($"Event with moniker {moniker} could not be found.");

                var updated = await _eventService.Update(model, old.Id);
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