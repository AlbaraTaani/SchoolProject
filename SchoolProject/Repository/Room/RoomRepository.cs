using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _myDbConnection;

        public RoomRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }

        public List<Room> GetAllRooms()
        {
            // LINQ query syntax:
            List<Room> rooms = (from roomObj in _myDbConnection.Rooms
                                select roomObj).ToList();

            // LINQ method syntax:
            // List<Room> rooms = _myDbConnection.Rooms.ToList();
            return rooms;
        }

        public void Create(Room room)
        {
            _myDbConnection.Rooms.Add(room);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = (from roomObj in _myDbConnection.Rooms
                         where roomObj.RoomId == id
                         select roomObj).FirstOrDefault();

            // Room room = _myDbConnection.Rooms.Find(id);

            if (room != null)
            {
                _myDbConnection.Rooms.Remove(room);
                _myDbConnection.SaveChanges();
            }
        }
    }
}
