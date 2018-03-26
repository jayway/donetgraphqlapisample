using System.Collections.Generic;
using System.Linq;
using GraphQlApi.Models;

namespace GraphQlApi.Repository
{
    public interface IBaseRepo<T>
    {
        T GetById(int id);
        IList<T> GetAll();
        T Update(T value);
        T Add(T value);
        void Delete(int id);
    }

    public class RoomRepo : IBaseRepo<Room>
    {
        private readonly IList<Room> _rooms;

        public RoomRepo(IList<Room> rooms)
        {
            _rooms = rooms;
        }

        public Room GetById(int id)
        {
            return _rooms.SingleOrDefault(r => r.Id == id);
        }

        public IList<Room> GetAll()
        {
            return _rooms;
        }

        public Room Update(Room room)
        {
            var roomToUpdate = _rooms.Single(r => r.Id == room.Id);
            roomToUpdate.RoomName = room.RoomName;
            return roomToUpdate;
        }

        public Room Add(Room room)
        {
            var id = _rooms.OrderByDescending(r => r.Id).First().Id;
            room.Id = id + 1;
            _rooms.Add(room);
            return room;
        }

        public void Delete(int id)
        {
            var roomToRemove = _rooms.First(r => r.Id == id);
            _rooms.Remove(roomToRemove);
        }
    }
}