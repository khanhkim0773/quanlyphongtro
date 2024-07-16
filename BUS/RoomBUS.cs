using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class RoomBUS
    {
        public static ObservableCollection<Room> GetRooms() 
        {
            return DAO.RoomDAO.GetRooms();
        }

        public static void AddRoom(Room room)
        {
            room.RoomStatus = "Chua thuê";
            DAO.RoomDAO.AddRoom(room);
        }

        public static void DeleteRoom(Room room)
        {
            DAO.RoomDAO.DeleteRoom(room);
        }

        public static Room GetRoomByRoomNumber(string roomNumber)
        {
            return DAO.RoomDAO.GetRoomByRoomNumber(roomNumber);
        }

        public static ObservableCollection<Room> GetListRoomByTenantName(string name) 
        {
            return DAO.RoomDAO.GetListRoomByTenantName(name);
        }
  
    }


}
