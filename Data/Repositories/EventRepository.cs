using BeforeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(BeforeAppContext context, ILogger<EventRepository> logger) : base(context, logger)
        {
        }

        //public void Add<T>(T entity) where T : class
        //{
        //    _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
        //    _context.Add(entity);
        //}

        //public void Delete<T>(T entity) where T : class
        //{
        //    _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
        //    _context.Remove(entity);
        //}

        //public async Task<bool> SaveChangesAsync()
        //{
        //    _logger.LogInformation($"Attempitng to save the changes in the context");

        //    // Only return success if at least one row was changed
        //    return (await _context.SaveChangesAsync()) > 0;
        //}

        public async Task<Event[]> GetAllEventsAsync()
        {
            _logger.LogInformation($"Getting all Events");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);

            query = query.OrderByDescending(c => c.EventDate);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByDateAsync(DateTime dateTime)
        {
            _logger.LogInformation($"Getting all Events");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);

            // Order It
            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate.Date == dateTime.Date);

            return await query.ToArrayAsync();

        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            _logger.LogInformation($"Getting a Event for {eventId}");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);


            // Query It
            query = query.Where(c => c.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<Event> GetEventByMonikerAsync(string moniker)
        {
            _logger.LogInformation($"Getting a Event for Moniker: {moniker}");

            return await table.FirstOrDefaultAsync(x => x.Moniker.Equals(moniker));

        }

    }
}
