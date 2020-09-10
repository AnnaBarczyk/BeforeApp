using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Data.Repositories;
using BeforeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController: ControllerBase
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;

        public LocationsController(ILocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<LocationModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllAsync();

                return _mapper.Map<LocationModel[]>(results);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("byid/{id:int}")]
        public async Task<ActionResult<LocationModel>> GetLocaiotnById(int id)
        {

            try
            {
                var result = await _repository.GetById(id);
                if (result == null) return NotFound();
                return _mapper.Map<LocationModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }


        [HttpPost]
        public async Task<ActionResult<LocationModel>> AddEvent(LocationModel model)
        {

            try
            {
                var newLocation = _mapper.Map<Location>(model);
                _repository.Add(newLocation);

                if (await _repository.SaveChangesAsync())
                { 
                    return Created($"/api/locations/{newLocation.Id}", _mapper.Map<LocationModel>(model));
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
                var oldLocaction = await _repository.GetById(id);
                if (oldLocaction == null) return NotFound("Location not found");

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
