using Microsoft.AspNetCore.Mvc;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicGenresController
    {
        private readonly IMusicGenresService _musicGenresService;

        public MusicGenresController(IMusicGenresService musicGenresService)
        {
            _musicGenresService = musicGenresService;
        }
    }
}
