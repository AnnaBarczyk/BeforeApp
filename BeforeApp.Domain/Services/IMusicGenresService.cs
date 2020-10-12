using BeforeApp.Domain.Models;
using System.Threading.Tasks;

namespace BeforeApp.Domain.Services
{
    public interface IMusicGenresService
    {
        public Task<int> Add(MusicGenreModel model);
        public Task<MusicGenreModel[]> GetAllMusicGenresAsync();
        public Task<MusicGenreModel> UpdateEntity(MusicGenreModel model, int id);

        public Task<MusicGenreModel> GetByIdAsync(int id);

        public Task<MusicGenreModel> GetByNameAsync(string name);

        public Task<bool> Delete(int id);

        public Task<int> GetIdByName(string name);

    }
}
