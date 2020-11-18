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

        public Task<IReadOnlyList<Booking>> GetBookingAsync()
        {
            throw new NotImplementedException();
        }

        public  async Task<Booking> GetBookingByUsername(string medname)
        {
            return _dbContext.Bookings
                  .Include(p => p.Customer)
                  .Include(p => p.Pharmacy)
                   .FirstOrDefault(p => p.MedicineName == medname);

            //var emp = _dbContext.Bookings.Where(Booking => Booking.MedicineName == medname).FirstOrDefault();
            //return emp;
        }

    }

      
    }

