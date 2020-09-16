using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        // General add delete
        void Add(T entity);
        void Delete(int id);

        Task<T> GetById(int id);

        Task<T[]> GetAllAsync();
        Task<bool> UpdateEntity(T entity);

        Task<bool> SaveChangesAsync();
    }
}