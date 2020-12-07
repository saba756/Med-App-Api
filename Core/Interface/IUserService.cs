using Core.Dtos;
using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
   public interface IUserService : IGenericRepository<AppUser>
    {
        Task<IList<AppUser>> GetPaginatedList(UserFilter userFilter);
    }
}
