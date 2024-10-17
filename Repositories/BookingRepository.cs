using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public void BookRoom(BookingReservation booking, BookingDetail bookingDetails) => BookingDAO.BookingRoom(booking, bookingDetails);

        public List<BookingReservation> GetAllBooking() => BookingDAO.GetAllBooking();
    }
}
