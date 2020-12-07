using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserFilter
    {
        public string SearchText { get; set; }
        public string SortBy { get; set; } = "name";
      
    }
}
