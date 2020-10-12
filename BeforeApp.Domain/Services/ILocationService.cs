﻿using BeforeApp.Domain.Models;
using System.Threading.Tasks;

namespace BeforeApp.Domain.Services
{
    public interface ILocationService
    {
        public Task<int> Add(LocationModel model);
        public Task<LocationModel> UpdateEntity(LocationModel model, int id);
        public Task<LocationModel[]> GetAllLocationsAsync();
        public Task<LocationModel> GetLocationByMonikerAsync(string moniker);
        public Task<LocationModel> GetLocationByIdAsync(int id);

        public Task<int> GetIdByMonikerAsync(string moniker);

        public Task<LocationModel[]> GetLocationsByParameters(string name,
            string locationCity, string adress);

        public Task<bool> Delete(int id);
        public Task<bool> Delete(string moniker);
    }
}
