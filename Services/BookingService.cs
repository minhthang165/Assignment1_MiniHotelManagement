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
        public bool BookRoom(BookingReservation booking, BookingDetail bookingDetails)
        {
            return iBookingRepository.BookRoom(booking, bookingDetails);
        }

        public List<BookingReservation> GetALlBooking()
        {
            return iBookingRepository.GetAllBooking();
        }
    }
}
