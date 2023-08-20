using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;

        public SubscribeController(ISubscribeService SubscribeService)
        {
            _SubscribeService = SubscribeService;
        }

        [HttpGet]
        public async Task<IActionResult> SubscribeList()
        {
            var values = await _SubscribeService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(Subscribe Subscribe)
        {
            await _SubscribeService.Insert(Subscribe);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var values = await _SubscribeService.GetById(id);


            await _SubscribeService.Delete(values);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(Subscribe Subscribe)
        {
            await _SubscribeService.Update(Subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribe(int id)
        {
            var value = await _SubscribeService.GetById(id);
            return Ok(value);
        }
    }
}
