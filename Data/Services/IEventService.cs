using BeforeApp.Data.Entities;
using BeforeApp.Models;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public interface IEventService
    {
        public void Add(EventModel model);
        public Task<EventModel> Update(EventModel model, int id);
        public Task<EventModel[]> Get();
        public Task<EventModel> GetByAsync(string moniker);
        public Task<EventModel> GetByAsync(int id);
    }
}