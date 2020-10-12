using BeforeApp.Data.Entities;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        public Task<Location[]> GetAllLocationsIncludeEventsAsync();
        public Task<Location> GetLocationByMonikerAsync(string moniker);
        public Task<Location> GetLocationByIdIncludeEventAsync(int id);
        public Task<Location[]> GetLocationsByParameters(string name,
            string locationCity, string adress);
    }
}