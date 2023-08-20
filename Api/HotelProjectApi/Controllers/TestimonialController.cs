using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _TestimonialService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(Testimonial Testimonial)
        {
            await _TestimonialService.Insert(Testimonial);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var values = await _TestimonialService.GetById(id);


            await _TestimonialService.Delete(values);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(Testimonial Testimonial)
        {
            await _TestimonialService.Update(Testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _TestimonialService.GetById(id);
            return Ok(value);
        }
    }
}
