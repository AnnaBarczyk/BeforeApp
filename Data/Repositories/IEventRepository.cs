using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IEventRepository
    {
        // General add delete
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Events 
        Task<Event[]> GetAllEventsAsync();
        Task<Event> GetEventAsync(int eventId);
        Task<Event[]> GetAllEventsByDate(DateTime dateTime);

    }
}