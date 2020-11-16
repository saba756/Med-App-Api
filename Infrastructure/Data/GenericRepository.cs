using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly StoreContext _dbContext;
        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  async Task<int> Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            var value = await SaveChangesAsync();
            return value;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }

        public System.Linq.IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                  .FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }
    }
}
