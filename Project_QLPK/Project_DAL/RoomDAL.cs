using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class RoomDAL
    {
        
        DataBaseDataContext db;
        public RoomDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<Room> getAllRoom()
        {
            return db.Rooms.ToList();
        }
        public Room getOneRoom(int Id)
        {
            return db.Rooms.Where(x => x.RoomID == Id).FirstOrDefault();
        }
        public void insertRoom(Room Room)
        {
            db.Rooms.InsertOnSubmit(Room);
            db.SubmitChanges();
        }
        public void updateRoom(Room Room)
        {
            var record = db.Rooms.Where(x => x.RoomID == Room.RoomID).FirstOrDefault();
            record.Room1 = Room.Room1;
            db.SubmitChanges();
        }
    }
}
