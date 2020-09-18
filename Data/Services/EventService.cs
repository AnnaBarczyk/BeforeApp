using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Data.Repositories;
using BeforeApp.Data.UnitOfWork;
using BeforeApp.Models;
using System;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<bool> Add(EventModel model)
        {
            var newEvent = _mapper.Map<Event>(model);
            
            return await _unitOfWork.Events.Add(newEvent);
        }

        public async Task<EventModel[]> GetAllEventsAsync()
        {
            var results = await _unitOfWork.Events.GetAllEventsAsync();

            return _mapper.Map<EventModel[]>(results);
        }

        public async Task<EventModel> UpdateEntity(EventModel model, int id)
        {

            var updated = _mapper.Map<Event>(model);
            updated.Id = id;
            if (!await _unitOfWork.Events.UpdateEntity(updated)) return null;

            return _mapper.Map<EventModel>(updated);
        }

        public async Task<EventModel> GetEventByMonikerAsync(string moniker) 
        {
            var eventByMoniker = await _unitOfWork.Events.GetEventByMonikerAsync(moniker);
            if (eventByMoniker == null) return null;
            else return _mapper.Map<EventModel>(eventByMoniker);
        }

        public async Task<EventModel> GetEventByIdAsync(int id)
        {
            var result = await _unitOfWork.Events.GetById(id);
            if (result == null) return null;
            return _mapper.Map<EventModel>(result);
        }

        public async Task<EventModel[]> GetEventsByParameters(string name, DateTime? dateTime, string locationName,
    string locationCity, string music, string artist)
        {
            var result = await _unitOfWork.Events.GetEventsByParameters(name, dateTime, locationName, locationCity, music, artist);

            return _mapper.Map<EventModel[]>(result);

        }

        public async Task<bool> Delete(int id)
        {
           return await _unitOfWork.Events.Delete(id);
        }

        public async Task<bool> Delete(string moniker)
        {
            var eventTodelete = await _unitOfWork.Events.GetEventByMonikerAsync(moniker);
            var id = eventTodelete.Id;

            return await _unitOfWork.Events.Delete(id);
        }

        public async Task<int> GetIdByMonikerAsync(string moniker)
        {
            var resultEvent = await _unitOfWork.Events.GetEventByMonikerAsync(moniker);
            if (resultEvent == null) return 0;

            return resultEvent.Id;
        }
    }
}