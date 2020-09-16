using BeforeApp.Data.Entities;
using BeforeApp.Models;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public interface IEventService
    {
        public void Add(EventModel model);
        public Task<EventModel> Update(EventModel model, int id);
        public Task<EventModel[]> GetAll();
        public Task<EventModel> GetEventByAsync(string moniker);
        public Task<EventModel> GetEventByAsync(int id);

        public Task<EventModel[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName,
            string locationCity, string music,string artist);
    }
}