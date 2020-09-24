using BeforeApp.Data.Entities;
using BeforeApp.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BeforeAppContext _context { get; }
        public IEventRepository Events { get; private set; }
        public IMusicGenreRepository MusicGenres { get; set; }
        public ILocationRepository Locations { get; private set; }

        public ILogger<Event> _eventLogger { get; set; }
        public ILogger<Location> _locationLogger { get; set; }

        

        public UnitOfWork(BeforeAppContext context, IEventRepository events, ILocationRepository locations,
            IMusicGenresRepository musicGenres, ILogger<Event> eventLogger, ILogger<Location> locationLogger)
        {
            _context = context;
            _eventLogger = eventLogger;
            _locationLogger = locationLogger;
            Events = events;
            Locations = locations;
            MusicGenres = musicGenres;
        }


        public async Task<int> Commit()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
