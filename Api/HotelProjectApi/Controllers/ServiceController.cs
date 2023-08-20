using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _ServiceService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddService(Service Service)
        {
            await _ServiceService.Insert(Service);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var values = await _ServiceService.GetById(id);


            await _ServiceService.Delete(values);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(Service Service)
        {
            await _ServiceService.Update(Service);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _ServiceService.GetById(id);
            return Ok(value);
        }
    }
}
