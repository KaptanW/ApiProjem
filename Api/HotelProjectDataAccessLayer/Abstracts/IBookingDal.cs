using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.Abstracts
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        Task BookingStatusChangeApproved(Booking booking);

        Task BookingStatusChangeApproved2(int id);
    }
}
