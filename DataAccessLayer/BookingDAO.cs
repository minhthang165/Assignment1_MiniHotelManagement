using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        private static string BOOKING_QUERY =        "INSERT INTO BookingReservation (BookingDate, TotalPrice, CustomerID, BookingStatus)" +
                                                     "VALUES (@BookingDate, @TotalPrice, @CustomerID, @BookingStatus)";

        private static string DETAIL_BOOKING_QUERY = "INSERT INTO BookingDetail (BookingReservationID, RoomID, StartDate, EndDate, ActualPrice) " +
                                                     "VALUES (@BookingReservationID, @RoomID, @StartDate, @EndDate, @ActualPrice)";

        public static void BookingRoom(BookingReservation booking, BookingDetail bookingDetails)
        {
            SqlParameter[] parametersForBooking = new SqlParameter[] {
                new SqlParameter("@BookingDate", booking.BookingDate),
                new SqlParameter("@TotalPrice", booking.TotalPrice),
                new SqlParameter("@CustomerID", booking.CustomerID),
                new SqlParameter("@BookingStatus", booking.BookingStatus)
            };

            SqlParameter[] parametersForDetail = new SqlParameter[] {
                new SqlParameter("@BookingReservationID", booking.BookingDate),
                new SqlParameter("@RoomID", bookingDetails.RoomID),
                new SqlParameter("@StartDate", bookingDetails.StartDate),
                new SqlParameter("@EndDate", bookingDetails.EndDate),
                new SqlParameter("@ActualPrice", bookingDetails.ActualPrice)
            };

            DBContext.ExecuteNonQuerry(BOOKING_QUERY, parametersForBooking);
            DBContext.ExecuteNonQuerry(DETAIL_BOOKING_QUERY, parametersForDetail);
        }
    }
}
