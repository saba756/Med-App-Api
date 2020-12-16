
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
   public  interface ITokenService
    {
        string CreateToken(User user);
        string GenerateRefreshToken();
        Task<UserToken> CreateRefreshToken(UserToken userToken);
    }
}
