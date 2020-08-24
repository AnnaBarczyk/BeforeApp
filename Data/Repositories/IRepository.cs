using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public interface IRepository<T> where T: class
    {
        // General add delete
        void Add(T entity);
        void Delete(int id);

        Task<T[]> GetAllAsync();

        Task<bool> SaveChangesAsync();
    }
}
