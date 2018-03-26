using System.Collections.Generic;
using System.Web.Http;
using GraphQlApi.Models;
using GraphQlApi.Repository;

namespace GraphQlApi.Controllers
{
    public class RoomController : ApiController
    {
        private readonly RoomRepo _roomRepo;

        public RoomController(RoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        // GET: api/Room
        public IEnumerable<Room> Get()
        {
            return _roomRepo.GetAll();
        }

        // GET: api/Room/5
        public Room Get(int id)
        {
            return _roomRepo.GetById(id);
        }

        // POST: api/Room
        public Room Post([FromBody]Room room)
        {
            return _roomRepo.AddRoom(room);
        }

        // PUT: api/Room/5
        public Room Put(int id, [FromBody]Room room)
        {
            return _roomRepo.UpdateRoom(room);
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
            _roomRepo.DeleteRoom(id);
        }
    }
}
