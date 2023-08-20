using HotelProjectWebUI.Dtos.ServicesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProjectWebUI.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IHttpClientFactory httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5124/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsondata);

                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddorEditService(int id = 0)
        {
            if (id != 0)
            {
                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5124/api/Service/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<CreateServiceDto>(jsondata);
                    return View(value);
                }

                return View();
            }
            else
            {

                return View();
            }
        }


        public async Task<IActionResult> AddorEditService(CreateServiceDto addServiceViewModel)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(addServiceViewModel);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            if (addServiceViewModel != null)
            {
                var responseMessage = await client.PutAsync("http://localhost:5124/api/Service", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var responseMessage = await client.PostAsync("http://localhost:5124/api/Service", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteService(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5124/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
