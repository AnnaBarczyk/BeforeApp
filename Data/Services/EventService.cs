using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Data.Repositories;
using BeforeApp.Models;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> Add(EventModel model)
        {
            var newEvent = _mapper.Map<Event>(model);
            
            return await _repository.Add(newEvent);
        }

        public async Task<EventModel[]> GetAll()
        {
            var results = await _repository.GetAllEventsAsync();

            return _mapper.Map<EventModel[]>(results);
        }

        public async Task<EventModel> Update(EventModel model, int id)
        {

            var updated = _mapper.Map<Event>(model);
            updated.Id = id;
            if (!await _repository.UpdateEntity(updated)) return null;

            return _mapper.Map<EventModel>(updated);
        }

        public async Task<EventModel> GetEventByAsync(string moniker) 
        {
            var eventByMoniker = await _repository.GetEventByMonikerAsync(moniker);
            if (eventByMoniker == null) return null;
            else return _mapper.Map<EventModel>(eventByMoniker);
        }

        public async Task<EventModel> GetEventByAsync(int id)
        {
            var result = await _repository.GetById(id);
            if (result == null) return null;
            return _mapper.Map<EventModel>(result);
        }

        public async Task<EventModel[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName,
    string locationCity, string music, string artist)
        {
            var result = await _repository.GetEventsByParameters(name, dateTime, locationName, locationCity, music, artist);

            return _mapper.Map<EventModel[]>(result);

        }

        public async Task<bool> Delete(int id)
        {
           return await _repository.Delete(id);
        }

        public async Task<bool> Delete(string moniker)
        {
            var eventTodelete = await _repository.GetEventByMonikerAsync(moniker);
            var id = eventTodelete.Id;

            return await _repository.Delete(id);
        }

        public async Task<int> GetIdByMonikerAsync(string moniker)
        {
            var resultEvent = await _repository.GetEventByMonikerAsync(moniker);
            if (resultEvent == null) return 0;

            return resultEvent.Id;
        }
    }
}