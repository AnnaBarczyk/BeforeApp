using BeforeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(BeforeAppContext context, ILogger<Location> logger) :
            base(context, logger) //zmienić loggera:(
        {
        }

        public async Task<Location[]> GetAllLocationsIncludeEventsAsync()
        {
            _logger.LogInformation("Getting all Events");

            IQueryable<Location> query = table
                .Include(c => c.Events);

            return await query.ToArrayAsync();
        }

        public async Task<Location> GetLocationByIdIncludeEventAsync(int id)
        {
            _logger.LogInformation($"Getting a Location for {id}");

            IQueryable<Location> query = _context.Locations
                .Include(c => c.Events);


            // Query It
            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public Task<Location> GetLocationByMonikerAsync(string moniker)
        {
            // TODO: migration
            _logger.LogInformation($"Getting a Event for Moniker: {moniker}");

            //return await table.AsNoTracking().FirstOrDefaultAsync(x => x.Moniker.Equals(moniker));
            throw new System.NotImplementedException();
        }

        public async Task<Location[]> GetLocationsByParameters(string name, string locationCity, string adress)
        {
            IQueryable<Location> allLocations = table
               .Include(c => c.Events);


            if (!string.IsNullOrEmpty(name)) allLocations = allLocations.Where(e => e.Name.Equals(name));

            if (!string.IsNullOrEmpty(locationCity))
                allLocations = allLocations.Where(e => e.City.Equals(locationCity));

            if (!string.IsNullOrEmpty(adress))
                allLocations = allLocations.Where(e => e.Adress.Equals(adress));

            return await allLocations.ToArrayAsync();
        }
    }
}