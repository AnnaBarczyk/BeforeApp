using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        // General add delete
        Task<bool> AddAsync(T entity);
        void Delete(int id);

        Task<T> GetById(int id);

        Task<T[]> GetAllAsync();
        void UpdateEntity(T entity);

    }
}