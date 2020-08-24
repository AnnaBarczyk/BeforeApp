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

        [HttpPost]
        public async Task<ActionResult<EventModel>> AddEvent(EventModel model)
        {

            try
            {
                var newEvent = _mapper.Map<Event>(model);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return BadRequest();
        }
    }

    }

