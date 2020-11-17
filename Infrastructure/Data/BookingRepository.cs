using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private StoreContext _dbContext;
        public BookingRepository(StoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public  async Task<Booking> GetBookingByUsername(string medname)
        {
          return _dbContext.Bookings
                .Include(p => p.PharmacyId)
                .Include(p => p.CustomerId)
                 .FirstOrDefault(p => p.MedicineName == medname);
         

        }

    }

      
    }

