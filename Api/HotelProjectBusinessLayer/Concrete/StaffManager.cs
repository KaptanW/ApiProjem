using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstracts;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task Delete(Staff t)
        {
            await _staffDal.Delete(t);
        }

        public async Task<Staff> GetById(int id)
        {

            return await _staffDal.GetById(id);
        }

        public async Task<List<Staff>> GetList()
        {
           return await _staffDal.GetList(); 
        }

        public async Task Insert(Staff t)
        {
            await _staffDal.Insert(t);
        }

        public async Task Update(Staff t)
        {
            await _staffDal.Update(t);
        }
    }
}
