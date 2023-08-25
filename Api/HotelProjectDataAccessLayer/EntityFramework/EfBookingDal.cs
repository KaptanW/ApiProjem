using HotelProjectDataAccessLayer.Abstracts;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {

        }

        public async Task BookingStatusChangeApproved(Booking booking)
        {
            using (var context = new Context())
            {
               var values = await context.Bookings.Where(x => x.Id == booking.Id).FirstOrDefaultAsync();
                values.Status = "Onaylandı";
                await context.SaveChangesAsync();
            }
        }

        public async Task BookingStatusChangeApproved2(int id)
        {
            using (var context = new Context())
            {
                var values = await context.Bookings.FindAsync(id);
                values.Status = "Onaylandı";
                await context.SaveChangesAsync();
            }
        }
    }
}
