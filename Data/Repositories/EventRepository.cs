using BeforeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly BeforeAppContext _context;
        private readonly ILogger<EventRepository> _logger;

        public EventRepository(BeforeAppContext context, ILogger<EventRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Event[]> GetAllEventsAsync()
        {
            _logger.LogInformation($"Getting all Events");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);

            query = query.OrderByDescending(c => c.EventDate);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByDate(DateTime dateTime)
        {
            _logger.LogInformation($"Getting all Events");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);

            // Order It
            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate.Date == dateTime.Date);

            return await query.ToArrayAsync();

        }

        public async Task<Event> GetEventAsync(int eventId)
        {
            _logger.LogInformation($"Getting a Camp for {eventId}");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);


            // Query It
            query = query.Where(c => c.EventId == eventId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
