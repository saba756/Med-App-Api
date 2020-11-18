using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
  public  interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<int> Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);

        Task<int> SaveChangesAsync();
    }
}

