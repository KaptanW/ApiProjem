using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstracts;
using HotelProjectDataAccessLayer.EntityFramework;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task Delete(About t)
        {
            
            await _aboutDal.Delete(t);
        }

        public async Task<About> GetById(int id)
        {
            return await _aboutDal.GetById(id);
        }

        public async Task<List<About>> GetList()
        {
            return await _aboutDal.GetList();

        }

        public async Task Insert(About t)
        {
            await _aboutDal.Insert(t);
        }

        public async Task Update(About t)
        {
            await _aboutDal.Update(t);
        }
    }
}
