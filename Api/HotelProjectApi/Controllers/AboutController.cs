using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _AboutService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(About About)
        {
            await _AboutService.Insert(About);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var values = await _AboutService.GetById(id);


            await _AboutService.Delete(values);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(About About)
        {
            await _AboutService.Update(About);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _AboutService.GetById(id);
            return Ok(value);
        }
    }
}
