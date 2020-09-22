using System;
using System.Threading.Tasks;
using BeforeApp.Data.Entities;

namespace BeforeApp.Data.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        //// General add delete
        //void Add<T>(T entity) where T : class;
        //void Delete<T>(T entity) where T : class;
        //Task<bool> SaveChangesAsync();

        //Events 
        Task<Event[]> GetAllEventsIncludeLocationsAsync();
        Task<Event> GetEventByIdIncludeLocationAsync(int eventId);
        Task<Event[]> GetAllEventsByDateAsync(DateTime dateTime);

        Task<Event> GetEventByMonikerAsync(string moniker);

        Task<Event[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName, string locationCity,
            string music, string artist);
    }
}