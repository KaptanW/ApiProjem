using HotelProjectWebUI.Dtos.BookingDto;
using HotelProjectWebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProjectWebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5124/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsondata);

                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditBooking(int id)
        {


                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5124/api/Booking/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<AddStaffViewModel>(jsondata);
                    return View(value);
                }

                return View();
            
       

        }


        public async Task<IActionResult> EditBooking(ResultBookingDto ResultBookingDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(ResultBookingDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
          
                var responseMessage = await client.PutAsync("http://localhost:5124/api/Booking", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
           
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> ApprovedReservation(ApproveReservationDto approveReservationDto)
        {

            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(approveReservationDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"http://localhost:5124/api/Booking/UpdateReservation", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        } 


        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5124/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
