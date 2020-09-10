using BeforeApp.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(BeforeAppContext context, ILogger<EventRepository> logger) : base(context, logger) //zmienić loggera:(
        {
        }
    }
}
