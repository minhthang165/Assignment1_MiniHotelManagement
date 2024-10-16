using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypenNote { get; set; }

        public RoomType(int roomTypeID, string roomTypeName, string typeDescription, string typenNote)
        {
            RoomTypeID = roomTypeID;
            RoomTypeName = roomTypeName;
            TypeDescription = typeDescription;
            TypenNote = typenNote;
        }

        public RoomType() { }
    }
}
