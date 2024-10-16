using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookingDetail
    {
        public int BookingReservationID { get; set; } 
        public int RoomID { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ActualPrice { get; set; }

        public BookingDetail(int bookingReservationID, int roomID, DateTime startDate, DateTime endDate, decimal actualPrice)
        {
            BookingReservationID = bookingReservationID;
            RoomID = roomID;
            StartDate = startDate;
            EndDate = endDate;
            ActualPrice = actualPrice;
        }
    }
}
