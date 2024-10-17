using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository iBookingRepository = new BookingRepository();
        public void BookRoom(BookingReservation booking, BookingDetail bookingDetails)
        {
            iBookingRepository.BookRoom(booking, bookingDetails);
        }

        public List<BookingReservation> GetALlBooking()
        {
            return iBookingRepository.GetAllBooking();
        }
    }
}
