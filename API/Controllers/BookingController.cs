using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BookingController : BaseAPIController
    {
        private readonly IBookingRepository _bookingService;
        public BookingController(IBookingRepository bookingService)
        {
            _bookingService = bookingService;
        }
        /// <summary>
        /// For fetching specific booking detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("medicines/{medname}")]
        public async Task<IActionResult> getBookingByName(string medname)
        {
            var bookingName = await _bookingService.GetBookingByUsername(medname);
            return bookingName != null ? Ok(bookingName) : (IActionResult)NotFound();
        }

       

    }
}
