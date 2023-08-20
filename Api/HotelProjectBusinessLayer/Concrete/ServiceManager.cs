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
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public async Task Delete(Service t)
        {
            await _servicesDal.Delete(t);
        }

        public async Task<Service> GetById(int id)
        {
            return await _servicesDal.GetById(id);
        }

        public async Task<List<Service>> GetList()
        {
            return await _servicesDal.GetList();
        }

        public async Task Insert(Service t)
        {
            await _servicesDal.Insert(t);
        }

        public async Task Update(Service t)
        {
            await _servicesDal.Update(t);
        }
    }
}
