using BeforeApp.Data.Entities;
using System;
using System.Threading.Tasks;

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