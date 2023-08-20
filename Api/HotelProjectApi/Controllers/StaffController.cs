using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var values = await _staffService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(Staff staff)
        {
            await _staffService.Insert(staff);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var values = await _staffService.GetById(id);

            
               await _staffService.Delete(values);
            

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            await _staffService.Update(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var value = await _staffService.GetById(id);
            return Ok(value);
        }
    }
}
