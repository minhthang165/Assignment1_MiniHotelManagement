using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public void CreateNewRoom(RoomInformation room) => RoomDAO.CreateNewRoom(room);
        public void DeleteRoom(int roomId) => RoomDAO.DeleteRoom(roomId);

        public List<RoomInformation> GetAllRoom() => RoomDAO.GetAllRoom();

        public RoomInformation GetRoom(int roomId) => RoomDAO.GetRoom(roomId);

        public void UpdateRoom(RoomInformation room) =>  RoomDAO.UpdateRoom(room);
    }
}
