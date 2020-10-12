using BeforeApp.Data.Entities;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IMusicGenresRepository : IRepository<MusicGenre>
    {
        public Task<MusicGenre[]> GetAllMusicGenresAsync();
        public Task<MusicGenre> GetByNameAsync(string name);
        public Task<MusicGenre[]> GetAllIncludeEventsAsync();

    }
}
