using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        //// General add delete
        //void Add<T>(T entity) where T : class;
        //void Delete<T>(T entity) where T : class;
        //Task<bool> SaveChangesAsync();

        //Events 
        // Task<Event[]> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
        Task<Event[]> GetAllEventsByDateAsync(DateTime dateTime);

        Task<Event> GetEventByMonikerAsync(string moniker);

    }
}
