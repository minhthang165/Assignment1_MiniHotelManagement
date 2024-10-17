using BusinessObject;
using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        private static string SELECT_ALL_BOOKING = "SELECT * FROM [dbo].[BookingReservation]";

        private static string BOOKING_QUERY = "INSERT INTO BookingReservation (BookingReservationID, BookingDate, TotalPrice, CustomerID, BookingStatus)" +
                                                     "VALUES (@BookingReservationID, CAST(@BookingDate AS Date), @TotalPrice, @CustomerID, @BookingStatus)";

        private static string DETAIL_BOOKING_QUERY = "INSERT INTO BookingDetail (BookingReservationID, RoomID, StartDate, EndDate, ActualPrice) " +
                                                     "VALUES (@BookingReservationID, @RoomID,  CAST(@StartDate AS Date),  CAST(@EndDate AS Date), @ActualPrice)";

        public static bool BookingRoom(BookingReservation booking, BookingDetail bookingDetails)
        {
            SqlParameter[] parametersForBooking = new SqlParameter[] {
                new SqlParameter("@BookingReservationID", booking.BookingReservationID),
                new SqlParameter("@BookingDate", booking.BookingDate),
                new SqlParameter("@TotalPrice", booking.TotalPrice),
                new SqlParameter("@CustomerID", booking.CustomerID),
                new SqlParameter("@BookingStatus", booking.BookingStatus)
            };

            SqlParameter[] parametersForDetail = new SqlParameter[] {
                new SqlParameter("@BookingReservationID", booking.BookingReservationID),
                new SqlParameter("@RoomID", bookingDetails.RoomID),
                new SqlParameter("@StartDate", bookingDetails.StartDate),
                new SqlParameter("@EndDate", bookingDetails.EndDate),
                new SqlParameter("@ActualPrice", bookingDetails.ActualPrice)
            };

            DBContext.ExecuteNonQuerry(BOOKING_QUERY, parametersForBooking);
            DBContext.ExecuteNonQuerry(DETAIL_BOOKING_QUERY, parametersForDetail);
            return true;
        }

        public static List<BookingReservation> GetAllBooking()
        {
            List<BookingReservation> list = new List<BookingReservation>();
            DataTable dataTable = DBContext.ExecuteQuery(SELECT_ALL_BOOKING);

            foreach (DataRow row in dataTable.Rows) 
            {
                int BookReservationID = Convert.ToInt32(row["BookingReservationID"]);
                DateTime BookingDate = Convert.ToDateTime(row["BookingDate"]);
                decimal TotalPrice = Convert.ToDecimal(row["TotalPrice"]);
                BookingStatus bookingStatus = (BookingStatus)Convert.ToInt32(row["BookingStatus"]);
                int CustomerId = Convert.ToInt32(row["CustomerID"]);

                BookingReservation bookingReservation = new BookingReservation(BookReservationID, BookingDate, TotalPrice, bookingStatus, CustomerId);
                list.Add(bookingReservation);
            }
            return list;
        }
    }
}
