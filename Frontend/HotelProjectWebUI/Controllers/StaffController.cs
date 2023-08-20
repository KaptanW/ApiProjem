using HotelProjectWebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProjectWebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5124/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsondata);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddorEditStaff(int id=0)
        {
            if (id != 0)
            {
                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5124/api/Staff/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsondata= await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<AddStaffViewModel>(jsondata);
                    return View(value);
                }

                return View();
            }
            else
            {

                return View();
            }
        }


        public async Task<IActionResult> AddorEditStaff(AddStaffViewModel addStaffViewModel)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(addStaffViewModel);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            if(addStaffViewModel != null)
            {
                var responseMessage = await client.PutAsync("http://localhost:5124/api/Staff", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
            var responseMessage = await client.PostAsync("http://localhost:5124/api/Staff", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5124/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
