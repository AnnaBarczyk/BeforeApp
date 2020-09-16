using BeforeApp.Data.Entities;
using Microsoft.Extensions.Logging;

namespace BeforeApp.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(BeforeAppContext context, ILogger<Location> logger) :
            base(context, logger) //zmienić loggera:(
        {
        }
    }
}