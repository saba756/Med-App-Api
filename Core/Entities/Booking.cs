using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
   public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string MedicineFormula { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? DateCreated { get; set; } = System.DateTime.Now;
        public DateTime?DateModified { get; set; } = System.DateTime.Now;
        public OrderPlaced OrdersPlaced { get; set; }
        public Customer Customer { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
