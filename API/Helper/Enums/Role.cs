using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper.Enums
{
    
        public enum roles
        {
            [Description("Pharmestics")]
            Pharmacy = 1,
            [Description("Customer")]
            Customer = 2,
            [Description("Delivery boy")]
            DeliveryBoy = 3,
           

        }
    
}
