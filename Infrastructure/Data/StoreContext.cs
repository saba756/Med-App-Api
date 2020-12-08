using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
   public class StoreContext : IdentityDbContext<AppUser>
    {

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderPlaced>orderPlaceds { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<ReviewType> ReviewTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
           
        }
        //public static StoreContext Create()
        //{
        //    return new StoreContext();
        //}
    }
}
