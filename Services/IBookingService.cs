using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingService
    {
        void BookRoom(BookingReservation booking, BookingDetail bookingDetails);

        List<BookingReservation> GetALlBooking();
    }
}
