using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Data.Repositories;
using BeforeApp.Data.Services;
using BeforeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController: ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpGet]
        public async Task<ActionResult<LocationModel[]>> Get()
        {
            try
            {
                return await _locationService.GetAllLocationsAsync();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("byid/{id:int}")]
        public async Task<ActionResult<LocationModel>> GetLocationById(int id)
        {

            try
            {
                var result = await _locationService.GetLocationByIdAsync(id);
                if (result == null) return NotFound($"No location with requested Id: {id}");
                return result;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<LocationModel>> GetLocationByMoniker(string moniker)
        {
            try
            {
                var result = await _locationService.GetLocationByMonikerAsync(moniker);
                if (result == null) return NotFound($"No location with requested moniker: {moniker}");
                return result;
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<LocationModel[]>> SearchByVarious(string name, string locationCity, string adress)
        {
            try
            {
                var results = await _locationService.GetLocationsByParameters(name, locationCity, adress);
                if (!results.Any()) return NotFound();
                return results;

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPost]
        public async Task<ActionResult<LocationModel>> AddLocation(LocationModel model)
        {

            try
            {
                var existing = await _locationService.GetLocationByMonikerAsync(model.Moniker);
                if (existing != null) return BadRequest("Moniker is in use");
                if (await _locationService.Add(model) > 0) return Created($"/api/locations/{model.Moniker}", model);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

        [HttpDelete("byId/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var oldLocaction = await _locationService.GetLocationByIdAsync(id);
                if (oldLocaction == null) return NotFound("Location not found");
                if (await _locationService.Delete(id)) return Ok("Deleted");

                return BadRequest("Not Able to delete");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpDelete("{moniker}")]
        public async Task<ActionResult> Delete(string moniker)
        {
            try
            {
                var oldLocation = await _locationService.GetLocationByMonikerAsync(moniker);
                if (oldLocation == null) return NotFound("Location not found");
                if (await _locationService.Delete(moniker)) return Ok("Deleted");

                return BadRequest("Not able to delete");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPut("{moniker}")]
        public async Task<ActionResult<LocationModel>> UpdateLocation(LocationModel model, string moniker)
        {
            try
            {
                var id = await _locationService.GetIdByMonikerAsync(moniker);
                if (id <= 0) return NotFound($"Location with moniker {moniker} could not be found");
                var updated = await _locationService.UpdateEntity(model, id);
                if (updated ==  null) return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");

                return updated;
            }
            catch (Exception)
            {

                return BadRequest("Failed to update");
            }
        }
    }
}
