using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
  public  class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Register = new Register
                    {
                        FirstName = "Bob",
                        LastName = "Bobbity",
                        Address = "10 The Street",
                        City = "New York",
                        ZipCode = "90210",
                        PhoneNo ="0512345"
                    }
                };

              var result =  await userManager.CreateAsync(user, "Pa$$w0rd");
                Console.WriteLine(result);
            }
        }
    }
}

