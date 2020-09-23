using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Data.UnitOfWork;
using BeforeApp.Models;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(EventModel model)
        {
            var newEvent = _mapper.Map<Event>(model);

            if (model.LocationId > 0)
            {
                var location = await _unitOfWork.Locations.GetById(model.LocationId);
                if (location != null) newEvent.Location = location;

                // Location id = 1 stands for "Default/No Location"
                else newEvent.Location = await _unitOfWork.Locations.GetById(1);            
            }
            else
            {
                // Location id = 1 stands for "Default/No Location"
                newEvent.Location = await _unitOfWork.Locations.GetById(1);
            }


            await _unitOfWork.Events.AddAsync(newEvent);

            return await _unitOfWork.Commit();
        }

        public async Task<EventModel[]> GetAllEventsAsync()
        {
            var results = await _unitOfWork.Events.GetAllEventsIncludeLocationsAsync();

            return _mapper.Map<EventModel[]>(results);
        }

        public async Task<EventModel> UpdateEntity(EventModel model, int id)
        {

            //var old = await _unitOfWork.Events.GetById(id);
            //var comparison = _mapper.Map<EventModel>(old);

            //var properties = typeof(EventModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (var property in properties)
            //{
            //    property.SetValue(property.GetValue(comparison) ?? property.GetValue(model), model);
            //}


            var updated = _mapper.Map<Event>(model);
            updated.Id = id;

            if (model.LocationId > 0)
            {
                var location = await _unitOfWork.Locations.GetById(model.LocationId);
                if (location != null) updated.Location = location;

                // Location id = 1 stands for "Default/No Location"
                else updated.Location = await _unitOfWork.Locations.GetById(1);
            }
            else
            {
                // Location id = 1 stands for "Default/No Location"
                updated.Location = await _unitOfWork.Locations.GetById(1);
            }


            _unitOfWork.Events.UpdateEntity(updated);

            if (await _unitOfWork.Commit() == 0) return null;
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
            _unitOfWork.Events.Delete(id);
            return await _unitOfWork.Commit() > 0;
        }

        public async Task<bool> Delete(string moniker)
        {
            var eventTodelete = await _unitOfWork.Events.GetEventByMonikerAsync(moniker);
            var id = eventTodelete.Id;
            _unitOfWork.Events.Delete(id);
            return await _unitOfWork.Commit() > 0;
        }

        public async Task<int> GetIdByMonikerAsync(string moniker)
        {
            var resultEvent = await _unitOfWork.Events.GetEventByMonikerAsync(moniker);
            if (resultEvent == null) return 0;

            return resultEvent.Id;
        }

    }
}