using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
  public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public DateTime? DateCreated { get; set; } = System.DateTime.Now;
        public DateTime? DateModified { get; set; } = System.DateTime.Now;
        public UserToken UserToken { get; set; }



    }
}
