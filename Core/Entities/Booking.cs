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
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Pharmacy")]
        public int PharmacyId{ get; set; }
        public string MedicineName { get; set; }
        public string MedicineFormula { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public OrderPlaced OrdersPlaced { get; set; }
    }
}
