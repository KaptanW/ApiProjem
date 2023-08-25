using HotelProjectWebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProjectWebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5124/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsondata);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddorEditRoom(int id = 0)
        {
            if (id != 0)
            {
                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5124/api/Room/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<ResultRoomDto>(jsondata);
                    return View(value);
                }

                return View();
            }
            else
            {

                return View();
            }
        }


        public async Task<IActionResult> AddorEditRoom(ResultRoomDto addRoomViewModel)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(addRoomViewModel);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            if (addRoomViewModel != null)
            {
                var responseMessage = await client.PutAsync("http://localhost:5124/api/Room", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var responseMessage = await client.PostAsync("http://localhost:5124/api/Room", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5124/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
