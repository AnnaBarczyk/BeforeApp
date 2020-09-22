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

        public Task<LocationModel[]> GetAllLocationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetIdByMonikerAsync(string moniker)
        {
            throw new NotImplementedException();
        }

        public Task<LocationModel> GetLocationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LocationModel> GetLocationByMonikerAsync(string moniker)
        {
            throw new NotImplementedException();
        }

        public Task<LocationModel[]> GetLocationsByParameters(string name, string locationCity, string adress)
        {
            throw new NotImplementedException();
        }

        public Task<LocationModel> UpdateEntity(LocationModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
