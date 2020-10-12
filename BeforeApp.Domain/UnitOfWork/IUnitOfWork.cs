using BeforeApp.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        ILocationRepository Locations { get; }
        IMusicGenresRepository MusicGenres { get; }
        public Task<int> Commit();
    }
}
