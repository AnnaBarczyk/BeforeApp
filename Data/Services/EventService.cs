﻿using AutoMapper;
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

        public void Add(EventModel model)
        {
            var newEvent = _mapper.Map<Event>(model);
            _repository.Add(newEvent);
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

        public async Task<Event> GetEventByAsync(string moniker) 
        {
            var eventByMoniker = await _repository.GetEventByMonikerAsync(moniker);
            if (eventByMoniker == null) return null;
            else return eventByMoniker;
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

    }
}