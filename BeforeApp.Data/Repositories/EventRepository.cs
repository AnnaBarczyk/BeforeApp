using BeforeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(BeforeAppContext context, ILogger<Event> logger) :
            base(context, logger) // Jakiej klasy powinien być logger??
        {
        }


        public async Task<Event[]> GetAllEventsIncludeLocationsAsync()
        {
            _logger.LogInformation("Getting all Events");

            IQueryable<Event> query = table
                .Include(c => c.Location);

            //query = query.OrderByDescending(c => c.EventDate);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByDateAsync(DateTime dateTime)
        {
            _logger.LogInformation("Getting all Events");

            IQueryable<Event> query = _context.Events
                .Include(c => c.Location);

            // Order It
            query = query.OrderByDescending(c => c.EventDate)
                .Where(c => c.EventDate.Date == dateTime.Date);

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdIncludeLocationAsync(int eventId)
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

            return await table.AsNoTracking().FirstOrDefaultAsync(x => x.Moniker.Equals(moniker));
        }

        public async Task<Event[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName,
            string locationCity, string music, string artist)
        {
            IQueryable<Event> allEvents = table
                .Include(c => c.Location)
                .Include(d => d.EventMusicGenres);


            if (!string.IsNullOrEmpty(name)) allEvents = allEvents.Where(e => e.Name.Equals(name));

            if (dateTime.HasValue) allEvents = allEvents.Where(e => e.EventDate.Equals(dateTime));

            if (!string.IsNullOrEmpty(locationCity))
                allEvents = allEvents.Where(e => e.Location.City.Equals(locationCity));

            if (!string.IsNullOrEmpty(locationName))
                allEvents = allEvents.Where(e => e.Location.Name.Equals(locationName));

            if (!string.IsNullOrEmpty(music))
                allEvents = allEvents.Where(e =>
                    e.EventMusicGenres.Any(m => m.MusicGenre.Name == music)); /* .Any(m => m.Name.Equals(music)));*/

            if (!string.IsNullOrEmpty(artist))
                allEvents = allEvents.Where(e => e.Artists.Any(a => a.Nickname.Equals(artist)));

            return await allEvents.ToArrayAsync();
        }
    }
}