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
using BeforeApp.Data.Entities;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EventModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllAsync();

                return _mapper.Map<EventModel[]>(results);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERRROROROROROR");
            }
        }

        // TODO: Implement HttpGet GetAllByDate()

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

        // TODO  [HttpGet("search")]


        [HttpPost]
        public async Task<ActionResult<EventModel>> AddEvent(EventModel model)
        {

            try
            {
                var existing = await _repository.GetEventByMonikerAsync(model.Moniker);
                if (existing != null) return BadRequest("Moniker in use already!");


                var newEvent = _mapper.Map<Event>(model);
                _repository.Add(newEvent);

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
    }

    }

