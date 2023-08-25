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
    public class BookingManager: IBookingService
    {
            private readonly IBookingDal _BookingDal;

            public BookingManager(IBookingDal BookingDal)
            {
                _BookingDal = BookingDal;
            }

        public async Task BookingStatusChangeApproved(Booking booking)
        {
            await _BookingDal.BookingStatusChangeApproved(booking);
        }

        public async Task BookingStatusChangeApproved2(int id)
        {
            await _BookingDal.BookingStatusChangeApproved2(id);
        }

        public async Task Delete(Booking t)
            {

                await _BookingDal.Delete(t);
            }

            public async Task<Booking> GetById(int id)
            {
                return await _BookingDal.GetById(id);
            }

            public async Task<List<Booking>> GetList()
            {
                return await _BookingDal.GetList();

            }

            public async Task Insert(Booking t)
            {
                await _BookingDal.Insert(t);
            }

            public async Task Update(Booking t)
            {
                await _BookingDal.Update(t);
            }
        
    }
}
