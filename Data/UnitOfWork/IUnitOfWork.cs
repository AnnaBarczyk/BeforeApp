using BeforeApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        ILocationRepository Locations { get; }
        IMusicGenreRepository MusicGenres { get; }
        public Task<int> Commit();
    }
}
