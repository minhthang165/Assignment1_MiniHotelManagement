using BusinessObject;
using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace DataAccessLayer
{
    public class RoomDAO
    {
        private static string SELECT_ALL_ROOM =     "SELECT " +
                                                        "RoomInformation.RoomID AS RoomID, \n" +
                                                        "RoomInformation.RoomNumber AS RoomNumber, \n" +
                                                        "RoomInformation.RoomDetailDescription AS RoomDetailDescription, \n" +
                                                        "RoomInformation.RoomMaxCapacity AS RoomMaxCapacity, \n" +
                                                        "RoomInformation.RoomStatus AS RoomStatus, \n" +
                                                        "RoomInformation.RoomPricePerDay AS RoomPricePerDay, \n" +
                                                        "RoomType.RoomTypeName AS RoomTypeName\n" +
                                                    "FROM [dbo].[RoomInformation] " +
                                                    "JOIN [dbo].[RoomType] ON RoomInformation.RoomTypeID = RoomType.RoomTypeID;";

        private static string SELECT_ROOM_BY_ID = "SELECT " +
                                                        "RoomInformation.RoomID AS RoomID, \n" +
                                                        "RoomInformation.RoomNumber AS RoomNumber, \n" +
                                                        "RoomInformation.RoomDetailDescription AS RoomDetailDescription, \n" +
                                                        "RoomInformation.RoomMaxCapacity AS RoomMaxCapacity, \n" +
                                                        "RoomInformation.RoomStatus AS RoomStatus, \n" +
                                                        "RoomInformation.RoomPricePerDay AS RoomPricePerDay, \n" +
                                                        "RoomType.RoomTypeName AS RoomTypeName\n" +
                                                    "FROM [dbo].[RoomInformation] " +
                                                    "JOIN [dbo].[RoomType] ON RoomInformation.RoomTypeID = RoomType.RoomTypeID;\n" +
                                                    "WHERE RoomID = @RoomID";

        private static string INSERT_NEW_ROOM = "INSERT INTO [dbo].[RoomInformation] (RoomNumber, RoomDetailDescription, RoomMaxCapacity, RoomStatus, RoomPricePerDay, RoomTypeID)\n" +
                                                    "VALUES (@RoomNumber, @RoomDetailDescription, @RoomMaxCapacity, @RoomStatus, @RoomPricePerDay, @RoomTypeID)";
        
        private static string UPDATE_ROOM_BY_ID =   "UPDATE [dbo].[RoomInformation]\n" +
                                                    "SET\n" +
                                                        "RoomNumber = @RoomNumber, \n" +
                                                        "RoomDetailDescription = @RoomDetailDescription,\n" +
                                                        "RoomMaxCapacity = @RoomMaxCapacity,\n" +
                                                        "RoomStatus = @RoomStatus,\n" +
                                                        "RoomPricePerDay = @RoomPricePerDay,\n" +
                                                        "RoomTypeID = @RoomTypeID\n" +
                                                    "WHERE  RoomID = @RoomID";
        private static string DELETE_ROOM_BY_ID =   "DELETE FROM [dbo].[RoomInformation]\n" +
                                                    "WHERE RoomID = @RoomID;";

        public static List<RoomInformation> GetAllRoom()
        {
            List<RoomInformation> list = new List<RoomInformation>();
            DataTable dataTable = DBContext.ExecuteQuery(SELECT_ALL_ROOM);

            foreach (DataRow row in dataTable.Rows)
            {
                int RoomID = Convert.ToInt32(row["RoomID"]);
                string RoomNumber = row["RoomNumber"].ToString();
                string RoomDescription = row["RoomDetailDescription"].ToString();
                int RoomMaxCapacity = Convert.ToInt32(row["RoomMaxCapacity"]);
                RoomStatus RoomStatus = (RoomStatus)Convert.ToInt32(row["RoomStatus"]);
                decimal RoomPricePerDate = Convert.ToDecimal(row["RoomPricePerDay"]);
                string RoomTypeName = row["RoomTypeName"].ToString();

                RoomInformation room = new RoomInformation(RoomID, RoomNumber, RoomDescription, RoomMaxCapacity, RoomStatus, RoomPricePerDate, RoomTypeName);
                list.Add(room);
            }
            return list;
        }

        public static void CreateNewRoom(RoomInformation room)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@RoomNumber", room.RoomNumber),
                new SqlParameter("@RoomDetailDescription", room.RoomDescription),
                new SqlParameter("@RoomMaxCapacity", room.RoomMaxCapacity),
                new SqlParameter("@RoomStatus", room.RoomStatus),
                new SqlParameter("@RoomPricePerDay", room.RoomPricePerDate)
            };

            DBContext.ExecuteNonQuerry(INSERT_NEW_ROOM, parameters);
        }

        public static void UpdateRoom(RoomInformation room)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@RoomNumber", room.RoomNumber),
                new SqlParameter("@RoomDetailDescription", room.RoomDescription),
                new SqlParameter("@RoomMaxCapacity", room.RoomMaxCapacity),
                new SqlParameter("@RoomStatus", room.RoomStatus),
                new SqlParameter("@RoomPricePerDay", room.RoomPricePerDate),
                new SqlParameter("RoomTypeID", room.RoomTypeID),
                new SqlParameter("RoomID", room.RoomID)
            };

            DBContext.ExecuteNonQuerry(UPDATE_ROOM_BY_ID, parameters);
        }

        public static void DeleteRoom(int RoomId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoomID", RoomId) };

            DBContext.ExecuteNonQuerry(DELETE_ROOM_BY_ID, parameters);
        }

        public static RoomInformation GetRoom(int RoomId) 
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoomID", RoomId) };
            DataTable dataTable = DBContext.ExecuteQuery(SELECT_ROOM_BY_ID, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                int RoomID = Convert.ToInt32(row["RoomID"]);
                string RoomNumber = row["RoomNumber"].ToString();
                string RoomDescription = row["RoomDetailDescription"].ToString();
                int RoomMaxCapacity = Convert.ToInt32(row["RoomMaxCapacity"]);
                RoomStatus RoomStatus = (RoomStatus)Convert.ToInt32(row["RoomStatus"]);
                decimal RoomPricePerDate = Convert.ToDecimal(row["RoomPricePerDay"]);
                string RoomTypeName = row["RoomTypeName"].ToString();

                return new RoomInformation(RoomID, RoomNumber, RoomDescription, RoomMaxCapacity, RoomStatus, RoomPricePerDate, RoomTypeName);

            }
            return null;
        }
    }
}
