
using BeforeApp.Models;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public interface IEventService
    {
        public Task<bool> Add(EventModel model);
        public Task<EventModel> UpdateEntity(EventModel model, int id);
        public Task<EventModel[]> GetAllEventsAsync();
        public Task<EventModel> GetEventByMonikerAsync(string moniker);
        public Task<EventModel> GetEventByIdAsync(int id);

        public Task<int> GetIdByMonikerAsync(string moniker);

        public Task<EventModel[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName,
            string locationCity, string music,string artist);

        public Task<bool> Delete(int id);
        public Task<bool> Delete(string moniker);

    }
}