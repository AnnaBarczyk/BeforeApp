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
    public class MusicGenresService : IMusicGenresService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MusicGenresService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Add(MusicGenreModel model)
        {
            var newGenre = _mapper.Map<MusicGenre>(model)
                await _unitOfWork.
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MusicGenreModel[]> GetAllMusicGenresAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MusicGenreModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MusicGenreModel[]> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MusicGenreModel> UpdateEntity(MusicGenreModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
