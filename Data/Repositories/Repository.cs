using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BeforeAppContext _context;
        protected readonly ILogger<EventRepository> _logger;
        private DbSet<T> table = null;

        public Repository(BeforeAppContext context, ILogger<EventRepository> logger)
        {
            
            _context = context;
            _logger = logger;
            table = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete(int id)
        {

            //_logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");

            var entity = table.Find(id);
            _context.Remove(entity);
        }

        public async Task<T[]> GetAllAsync()
        {
            return await table.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
