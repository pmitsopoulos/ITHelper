using ITHelper.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await applicationDbContext.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entityTBD = await GetByIdAsync(id);
            applicationDbContext.Remove(entityTBD);
        }

        public async Task<bool> Exists(int id)
        {
            var entityTBF = await GetByIdAsync(id);
            return entityTBF != null;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await applicationDbContext.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entityTBR = await applicationDbContext.Set<T>().FindAsync(id);
            return entityTBR;
        }

        //To be Discontinued
        public async Task<IEnumerable<T>> GetBySearchTermAsync(string searchTerm)
        {
            var properties = typeof(T).GetProperties().Where(p=>p.PropertyType == typeof(string));
            var entities =  GetAllAsync().Result.Where(e =>
            {
                var exists = false;
                foreach (var property in properties)
                {
                    exists = property.GetValue(e).ToString().ToLower().Contains(searchTerm.ToLower());
                    if (exists)
                    {
                        break;
                    }
                }
                return exists;
            });
            
            return entities;
                
        }

        public async Task UpdateAsync(T entity)
        {
            applicationDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
