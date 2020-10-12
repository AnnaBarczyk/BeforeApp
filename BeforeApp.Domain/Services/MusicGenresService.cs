using BeforeApp.Domain.UnitOfWork;
using BeforeApp.Domain.Models;
using System.Threading.Tasks;
using AutoMapper;
using BeforeApp.Data.Entities;

namespace BeforeApp.Domain.Services
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
            var newGenre = _mapper.Map<MusicGenre>(model);
            await _unitOfWork.MusicGenres.AddAsync(newGenre);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(int id)
        {
            _unitOfWork.MusicGenres.Delete(id);
            return await _unitOfWork.Commit() > 0;
        }

        public async Task<MusicGenreModel[]> GetAllMusicGenresAsync()
        {
            var result = await _unitOfWork.MusicGenres.GetAllIncludeEventsAsync();
            return _mapper.Map<MusicGenreModel[]>(result);
        }

        public async Task<MusicGenreModel> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.MusicGenres.GetByIdAsync(id);
            if (result == null) return null;
            return _mapper.Map<MusicGenreModel>(result);
        }

        public async Task<MusicGenreModel> GetByNameAsync(string name)
        {
            var result = await _unitOfWork.MusicGenres.GetByNameAsync(name);
            if (result == null) return null;
            return _mapper.Map<MusicGenreModel>(result);
        }

        public async Task<int> GetIdByName(string name)
        {
            var result = await _unitOfWork.MusicGenres.GetByNameAsync(name);

            if (result == null) return 0;

            return result.Id;
        }

        public async Task<MusicGenreModel> UpdateEntity(MusicGenreModel model, int id)
        {
            var updated = _mapper.Map<MusicGenre>(model);
            updated.Id = id;
            _unitOfWork.MusicGenres.UpdateEntity(updated);

            if (await _unitOfWork.Commit() == 0) return null;
            return _mapper.Map<MusicGenreModel>(updated);
        }
    }
}
