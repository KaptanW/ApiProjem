using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstracts;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public async Task Delete(Room t)
        {
          await _roomDal.Delete(t);
        }

        public async Task<Room> GetById(int id)
        {
            return await _roomDal.GetById(id);
        }

        public async Task<List<Room>> GetList()
        {
            return await _roomDal.GetList();
            
        }

        public async Task Insert(Room t)
        {
            await _roomDal.Insert(t);
        }

        public async Task Update(Room t)
        {
            await _roomDal.Update(t);
        }
    }
}
