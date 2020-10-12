using BeforeApp.Domain.Services;
using BeforeApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicGenresController : ControllerBase
    {
        private readonly IMusicGenresService _musicGenresService;

        public MusicGenresController(IMusicGenresService musicGenresService)
        {
            _musicGenresService = musicGenresService;
        }

        [HttpGet]
        public async Task<ActionResult<MusicGenreModel[]>> Get()
        {
            try
            {
                return await _musicGenresService.GetAllMusicGenresAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }

        [HttpGet("byid/{id:int}")]
        public async Task<ActionResult<MusicGenreModel>> GetGenreById(int id)
        {
            try
            {
                var result = await _musicGenresService.GetByIdAsync(id);
                if (result == null) return NotFound($"No music genre with requested id: {id}");
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MusicGenreModel>> AddGenre(MusicGenreModel model)
        {
            try
            {
                var existing = await _musicGenresService.GetByNameAsync(model.Name);
                if (existing != null) return BadRequest("Music genre with current name already exist");
                if (await _musicGenresService.Add(model) > 0) return Created($"/api/musicgenres/{model.Name}", model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
            return BadRequest();
        }

        [HttpDelete("byid/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var oldGenre = await _musicGenresService.GetByIdAsync(id);
                if (oldGenre == null) return NotFound("Music Genre not found");
                if (await _musicGenresService.Delete(id)) return Ok("Deleted");
                return BadRequest("Not able to delete");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<MusicGenreModel>> UpdateGenre(MusicGenreModel model, string name)
        {
            try
            {
                var id = await _musicGenresService.GetIdByName(name);
                if (id <= 0) return NotFound($"Music genre with name: {name} could not be found");
                var updated = await _musicGenresService.UpdateEntity(model, id);
                if (updated == null) return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update");
                return updated;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database update");
            }
        }

    }
}
