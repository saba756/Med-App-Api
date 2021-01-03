using API.Helper.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public static class Policies
    {
      
        public static AuthorizationPolicy PharmacyPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(roles.Pharmacy.ToString()).Build();
        }

        public static AuthorizationPolicy CustomerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(roles.Customer.ToString()).Build();
        }
        public static AuthorizationPolicy DeliveryBoyPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(roles.DeliveryBoy.ToString()).Build();
        }
    }
}
