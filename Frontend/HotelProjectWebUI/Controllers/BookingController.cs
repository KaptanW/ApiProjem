using HotelProjectWebUI.Dtos.BookingDto;
using HotelProjectWebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProjectWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        } 
        
        
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto create)
        {
            create.Status = "Onay Bekliyor";
            create.Description = "";
            //if (!ModelState.IsValid)
            //{
            //     return RedirectToAction("Index");
            //}
           
             
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(create);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5124/api/Booking/UpdateBooking", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }

            return PartialView();
        }
    }
}
