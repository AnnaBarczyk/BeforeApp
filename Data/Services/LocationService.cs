using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Data.UnitOfWork;
using BeforeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Add(LocationModel model)
        {
            var newLocation = _mapper.Map<Location>(model);
            await _unitOfWork.Locations.AddAsync(newLocation);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(int id)
        {
            _unitOfWork.Locations.Delete(id);
            return await _unitOfWork.Commit() > 0;
        }

        public async Task<bool> Delete(string moniker)
        {
            var locationToDelete = await _unitOfWork.Locations.GetLocationByMonikerAsync(moniker);
            var id = locationToDelete.Id;
            _unitOfWork.Locations.Delete(id);
            return await _unitOfWork.Commit() > 0;
        }

        public async Task<LocationModel[]> GetAllLocationsAsync()
        {
            var results = await _unitOfWork.Locations.GetAllLocationsIncludeEventsAsync();
            return _mapper.Map<LocationModel[]>(results);
        }

        public async Task<int> GetIdByMonikerAsync(string moniker)
        {
            var result = await _unitOfWork.Locations.GetLocationByMonikerAsync(moniker);
            if (result == null) return 0;
            return result.Id;
        }

        public async Task<LocationModel> GetLocationByIdAsync(int id)
        {
            var result = await _unitOfWork.Locations.GetById(id);
            if (result == null) return null;
            return _mapper.Map<LocationModel>(result);
        }

        public async Task<LocationModel> GetLocationByMonikerAsync(string moniker)
        {
            var result = await _unitOfWork.Locations.GetLocationByMonikerAsync(moniker);
            if (result == null) return null;
            return _mapper.Map<LocationModel>(result);
        }

        public async Task<LocationModel[]> GetLocationsByParameters(string name, string locationCity, string adress)
        {
            var results = await _unitOfWork.Locations.GetLocationsByParameters(name, locationCity, adress);
            return _mapper.Map<LocationModel[]>(results);
        }

        public async Task<LocationModel> UpdateEntity(LocationModel model, int id)
        {
            var updated = _mapper.Map<Location>(model);
            updated.Id = id;
            _unitOfWork.Locations.UpdateEntity(updated);
            if (await _unitOfWork.Commit() == 0) return null;
            return _mapper.Map<LocationModel>(updated);
        }
    }
}
