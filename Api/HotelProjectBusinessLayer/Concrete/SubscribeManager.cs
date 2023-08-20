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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public async Task Delete(Subscribe t)
        {
            await _subscribeDal.Delete(t);
        }

        public async Task<Subscribe> GetById(int id)
        {
            return await _subscribeDal.GetById(id);
        }

        public async Task<List<Subscribe>> GetList()
        {
            return await _subscribeDal.GetList();
        }

        public async Task Insert(Subscribe t)
        {
            await _subscribeDal.Insert(t);
        }

        public async Task Update(Subscribe t)
        {
            await _subscribeDal.Update(t);
        }
    }
}
