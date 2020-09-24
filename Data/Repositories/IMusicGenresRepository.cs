using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IMusicGenresRepository : IRepository<MusicGenre>
    {
        public Task<MusicGenre[]> GetAllMusicGenresAsync();
        public Task<MusicGenre[]> GetByNameAsync(string name);

    }
}
