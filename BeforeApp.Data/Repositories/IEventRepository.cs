using System;
using System.Threading.Tasks;
using BeforeApp.Data.Entities;

namespace BeforeApp.Data.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event[]> GetAllEventsIncludeLocationsAsync();
        Task<Event> GetEventByIdIncludeLocationAsync(int eventId);
        Task<Event[]> GetAllEventsByDateAsync(DateTime dateTime);

        Task<Event> GetEventByMonikerAsync(string moniker);

        Task<Event[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName, string locationCity,
            string music, string artist);
    }
}