
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
{
   public class AppUser: IdentityUser
    {

        public string Email { get; set; }
        public Register Register { get; set; }
    }
}

