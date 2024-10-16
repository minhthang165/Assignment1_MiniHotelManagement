
using BusinessObject.Enums;

namespace BusinessObject
{
    public class RoomInformation
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } // max length: 50
        public string RoomDescription { get; set; } // max length: 220
        public int RoomMaxCapacity { get; set; }
        public RoomStatus RoomStatus { get; set; } // 1: Active, 2: Deleted
        public decimal RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; } // FK to RoomType

        public RoomType RoomType { get; set; }


        public RoomInformation(int roomID, string roomNumber, string roomDescription, int roomMaxCapacity, 
            RoomStatus roomStatus, decimal roomPricePerDate, string RoomTypeName)
        {
            RoomID = roomID;
            RoomNumber = roomNumber;
            RoomDescription = roomDescription;
            RoomMaxCapacity = roomMaxCapacity;
            RoomStatus = roomStatus;
            RoomPricePerDate = roomPricePerDate;
            RoomTypeName = RoomTypeName;
            
        }

        public RoomInformation(int roomID, string roomNumber, string roomDescription, int roomMaxCapacity, RoomStatus roomStatus, decimal roomPricePerDate, int roomTypeID)
        {
            RoomID = roomID;
            RoomNumber = roomNumber;
            RoomDescription = roomDescription;
            RoomMaxCapacity = roomMaxCapacity;
            RoomStatus = roomStatus;
            RoomPricePerDate = roomPricePerDate;
            RoomTypeID = roomTypeID;
        }

        public RoomInformation() { }
    }

}
