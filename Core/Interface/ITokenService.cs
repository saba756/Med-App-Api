using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface
{
   public  interface ITokenService
    {
        string CreateToken(AppUser user);
        string GenerateRefreshToken();
    }
}
