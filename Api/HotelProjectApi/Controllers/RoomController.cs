using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }

        [HttpGet]
        public async Task<IActionResult> RoomList()
        {
            var values = await _RoomService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room Room)
        {
            await _RoomService.Insert(Room);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var values = await _RoomService.GetById(id);

            
               await _RoomService.Delete(values);
            

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room Room)
        {
            await _RoomService.Update(Room);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var value = await _RoomService.GetById(id);
            return Ok(value);
        }
    }
}
