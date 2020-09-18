using BeforeApp.Data.Entities;
using BeforeApp.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace BeforeApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BeforeAppContext _context { get; }
        public IEventRepository Events { get; private set; }
        public ILocationRepository Locations { get; private set; }
         public ILogger<Event> _eventLogger { get; set; }
         public ILogger<Location> _locationLogger { get; set; }

        public UnitOfWork(BeforeAppContext context, ILogger<Event> eventLogger, ILogger<Location> locationLogger)
        {
            _context = context;
            _eventLogger = eventLogger;
            _locationLogger = locationLogger;
            Events = new EventRepository(_context, _eventLogger);
            Locations = new LocationRepository(_context, _locationLogger);
        }


        public int Commit()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
