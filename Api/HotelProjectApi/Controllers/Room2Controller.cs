using AutoMapper;
using HotelProjectBusinessLayer.Abstract;
using HotelProjectDtoLayer.Dtos.RoomDto;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService roomService;

        private readonly IMapper mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await roomService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomAddDto Room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = mapper.Map<Room>(Room);
            await roomService.Insert(values);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto Room)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = mapper.Map<Room>(Room);
            await roomService.Update(values);
            return Ok();
        }
    }
}
