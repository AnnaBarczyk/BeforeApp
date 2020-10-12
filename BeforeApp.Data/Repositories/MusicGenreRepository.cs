using BeforeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class MusicGenreRepository : Repository<MusicGenre>, IMusicGenresRepository
    {
        public MusicGenreRepository(BeforeAppContext context, ILogger<MusicGenre> logger) : base(context, logger)
        {
        }

        public async Task<MusicGenre[]> GetAllIncludeEventsAsync()
        {
            var query = _context.MusicGenres.Include(e => e.EventMusicGenres)
                .ThenInclude(v => v.Event);
            return await query.ToArrayAsync();
        }

        public async Task<MusicGenre[]> GetAllMusicGenresAsync()
        {
            _logger.LogInformation("Getting all Music Genres");

            return await table.ToArrayAsync();
        }

        public async Task<MusicGenre> GetByNameAsync(string name)
        {
            _logger.LogInformation($"Getting {name} Music Genre by name ");

            return await table.AsNoTracking().FirstOrDefaultAsync(n => n.Name.Equals(name));
        }

    }
}
