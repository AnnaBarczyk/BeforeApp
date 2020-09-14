using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeforeApp.Data.Repositories;
using BeforeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using AutoMapper;
//using BeforeApp.Data.Entities;
using BeforeApp.Data.Services;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public EventsController(IEventRepository repository, IMapper mapper, IEventService eventService)
        {
            _repository = repository;
            _mapper = mapper;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<EventModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllEventsAsync();

                return _mapper.Map<EventModel[]>(results);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("byid/{id:int}")]
        public async Task<ActionResult<EventModel>> GetEventById(int id){

            try
            {
                var result =await _repository.GetById(id);
                if (result == null) return NotFound();
                return  _mapper.Map<EventModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            }
        
        [HttpGet("{moniker}")]
        public async Task<ActionResult<EventModel>> GetEventByMoniker(string moniker)
        {
            try
            {
                var result = await _repository.GetEventByMonikerAsync(moniker);
                if (result == null) return NotFound();
                return _mapper.Map<EventModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<EventModel[]>> SearchByVarious(string name = null, string locationName = null, DateTime? dateTime = null,
            string locationCity = null, string music = null, string artist = null)
        {
            var results = await _repository.GetEventsByParameters(name, dateTime, locationName, locationCity, music, artist);
            if (!results.Any()) return NotFound();
            return _mapper.Map<EventModel[]>(results);
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
                {
                    return Created($"/api/events/{model.Moniker}", _mapper.Map<EventModel>(model));
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
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

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Deleted");
                }

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
                var old = await _repository.GetEventByMonikerAsync(moniker);

                if (old == null) return NotFound($"Event with moniker {moniker} could not be found.");

                // można robić update bezpośrednio w kontrolerze za pomocą mappera:
                // _mapper.Map(model, old);

                var updated = _eventService.Update(model, old.Id);

                //var updated = _mapper.Map<Event>(model);
                //updated.Id = old.Id;
                //_repository.UpdateEntity(updated);


                if (await _repository.SaveChangesAsync())
                {
                    return updated;
                }
            }
            catch (Exception)
            {
                return BadRequest("Pan błąd");
            }

            return BadRequest("dupsko");
        }

    }

    }

