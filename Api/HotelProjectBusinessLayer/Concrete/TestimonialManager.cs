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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task Delete(Testimonial t)
        {
          await _testimonialDal.Delete(t);
        }

        public async Task<Testimonial> GetById(int id)
        {
          return await _testimonialDal.GetById(id);
        }

        public async Task<List<Testimonial>> GetList()
        {
           return await _testimonialDal.GetList();
        }

        public async Task Insert(Testimonial t)
        {
            await _testimonialDal.Insert(t);
        }

        public async Task Update(Testimonial t)
        {
            await _testimonialDal.Update(t);
        }
    }
}
