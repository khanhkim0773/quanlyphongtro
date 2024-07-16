using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RoomDAO
    {
        public static ObservableCollection<Room> GetRooms()
        {
            ObservableCollection<Room> rooms;
            using ( QLPTDataContext db = new QLPTDataContext())
            {
                List<Room> roomList = db.Rooms.Select(r => r).ToList();
                rooms = new ObservableCollection<Room>(roomList);

            }
            return rooms;
        }

        public static void AddRoom(Room room)
        {
            using (var db = new QLPTDataContext())
            {
                db.Rooms.InsertOnSubmit(room);
                db.SubmitChanges();
            }
        }

        public static void DeleteRoom(Room room) 
        {
            using ( var db = new QLPTDataContext())
            {
                Room existingRoom = db.Rooms.SingleOrDefault(r => r.RoomID == room.RoomID);
                if (existingRoom != null)
                {
                    db.Rooms.DeleteOnSubmit(existingRoom);
                    db.SubmitChanges();
                }
            }
        }

        public static void UpdateRoom(Room room)
        {
            using( var db = new QLPTDataContext())
            {
                Room existingRoom = db.Rooms.SingleOrDefault(r => r.RoomID == room.RoomID);
                if (existingRoom != null)
                {
        
                    db.SubmitChanges();
                }
            }
        }

        public static Room GetRoomByRoomNumber(string roomNumber)
        {
            using( var db = new QLPTDataContext())
            {
                Room existingRoom = db.Rooms.SingleOrDefault(r => r.RoomNumber == roomNumber);
                    return existingRoom;
            }
        }

        public static ObservableCollection<Room> GetListRoomByTenantName(string name)
        {
            ObservableCollection<Room> rooms;
            using (QLPTDataContext db = new QLPTDataContext())
            {
                List<Room> roomList = db.Rooms.Where(r => r.TenantName == name).ToList();
                rooms = new ObservableCollection<Room>(roomList);

            }
            return rooms;
        }    
    }
}
