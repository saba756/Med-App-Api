using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserDto
    {
        public string Token { get; set; }
        public string Displayname { get; set; }
        public string Email { get; set; }
    }
}
