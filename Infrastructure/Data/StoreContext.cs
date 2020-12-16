using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
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
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>()
             .HasOne(a => a.UserToken)
             .WithOne(a => a.User)
             .HasForeignKey<UserToken>(c => c.Id);
            base.OnModelCreating(modelbuilder);
            
        }
        
    }
}
