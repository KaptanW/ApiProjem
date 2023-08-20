using HotelProjectWebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProjectWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5124/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsondata);

                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> AddorEditTestimonial(int id = 0)
        {
            if (id != 0)
            {
                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5124/api/Testimonial/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<TestimonialViewModel>(jsondata);
                    return View(value);
                }

                return View();
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddorEditTestimonial(TestimonialViewModel addTestimonialViewModel)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(addTestimonialViewModel);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            if (addTestimonialViewModel != null)
            {
                var responseMessage = await client.PutAsync("http://localhost:5124/api/Testimonial", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var responseMessage = await client.PostAsync("http://localhost:5124/api/Testimonial", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5124/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
