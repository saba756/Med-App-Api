using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
  public  class UserToken
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string InvokebyIp { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
