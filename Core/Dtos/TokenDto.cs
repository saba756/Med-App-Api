using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
   public class TokenDto
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string UserType { get; set; }
    }
}
