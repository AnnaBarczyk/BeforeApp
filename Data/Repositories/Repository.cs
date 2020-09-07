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
        protected DbSet<T> table = null;

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

            var entity = table.Find(id);
            _context.Remove(entity);
            _logger.LogInformation($"Removing an object of type {entity.GetType()} from the context.");
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T[]> GetAllAsync()
        {
            return await table.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void UpdateEntity(T entity)
        {
            _logger.LogInformation($"Updating an object of type {entity.GetType()} to the context.");

            table.Attach(entity);
            var updatedEntity = _context.Entry(entity);

            // też działa!! 
            // Jaka jest różnica????
            // var updatedEntity = _context.Update(entity);   
            updatedEntity.State = EntityState.Modified;


            // ALTERNATYWNY UPDATE
            //public async Task<bool> UpdateEntity(T entity)
            //{
            //    _logger.LogInformation($"Updating an object of type {entity.GetType()} to the context.");

            //    var updatedEntity = _context.Update(entity);
            //    updatedEntity.State = EntityState.Modified;

            //    return (await _context.SaveChangesAsync()) > 0;

            //}
        }
    }
}
