using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeforeApp.Data.Repositories;
using BeforeApp.Data.Entities;
using AutoMapper;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using BeforeApp.Models;

namespace BeforeApp.Data.Services
{
    public class EventService: IEventService
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository repository, IMapper mapper )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add(EventModel model)
        {
            var newEvent = _mapper.Map<Event>(model);
            _repository.Add(newEvent);
        }

        public EventModel Update(EventModel model,int id)
        {
            var updated = _mapper.Map<Event>(model);
            updated.Id = id;
            _repository.UpdateEntity(updated);

            return _mapper.Map<EventModel>(updated);
        }
    }
}
