using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        // General add delete
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);

        Task<T> GetById(int id);

        Task<T[]> GetAllAsync();
        Task<bool> UpdateEntity(T entity);

        Task<bool> SaveChangesAsync();
    }
}