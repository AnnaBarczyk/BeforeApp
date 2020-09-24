using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BeforeApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BeforeAppContext _context;
        protected readonly ILogger<T> _logger;
        protected DbSet<T> table;

        public Repository(BeforeAppContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
            table = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");

            await _context.AddAsync(entity);

            return true;
        }

        public void Delete(int id)
        {
            var entity = table.Find(id);
            _context.Remove(entity);
            _logger.LogInformation($"Removing an object of type {entity.GetType()} from the context.");
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T[]> GetAllAsync()
        {
            return await table.ToArrayAsync();
        }

        public void UpdateEntity(T entity)
        {
            _logger.LogInformation($"Updating an object of type {entity.GetType()} to the context.");

            //table.Attach(entity);
            //var updatedEntity = _context.Entry(entity);

            var updatedEntity = _context.Update(entity);
 
            updatedEntity.State = EntityState.Modified;

        }
    }
}