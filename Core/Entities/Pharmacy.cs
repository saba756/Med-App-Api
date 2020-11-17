using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
   public class Pharmacy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public DateTime? DateCreated { get; set; } = System.DateTime.Now;
        public DateTime? DateModified { get; set; } = System.DateTime.Now;
       // public ICollection<Booking> Booking { get; set; }

    }
}
