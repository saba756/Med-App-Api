using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
   public class UserToken
    {
        public string revoked_by_ip { get; set; }
        public int Id { get; set; }
        public string UserType { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public User User { get; set; }
    }
}
