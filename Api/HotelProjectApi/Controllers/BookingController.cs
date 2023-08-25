using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var values = await _BookingService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking Booking)
        {
            await _BookingService.Insert(Booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var values = await _BookingService.GetById(id);


            await _BookingService.Delete(values);


            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(Booking Booking)
        {
            await _BookingService.Update(Booking);
            return Ok();
        }
        
        [HttpPut("UpdateReservation")]
        public async Task<IActionResult> UpdateReservation(Booking Booking)
        {
            await _BookingService.BookingStatusChangeApproved(Booking);
            return Ok();
        } 
        
        [HttpPut("UpdateReservation2")]
        public async Task<IActionResult> UpdateReservation2(int id)
        {
            await _BookingService.BookingStatusChangeApproved2(id);
            return Ok();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var value = await _BookingService.GetById(id);
            return Ok(value);
        }
    }
}
