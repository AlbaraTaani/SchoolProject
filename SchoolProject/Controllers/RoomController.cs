using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class RoomController: Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View(rooms);
        }
        [HttpGet]
        public IActionResult GetAllRooms()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index", rooms);
        }

        [HttpGet]
        public ViewResult Create()
        {
            // Logic to render the creation view
            return View();
        }
        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);
            }
            return View("Index", _roomRepository.GetAllRooms());
        }

        [HttpPost]
        public IActionResult Delete(int roomId)
        {
            _roomRepository.Delete(roomId);
            return View("Index",_roomRepository.GetAllRooms());
        }
    }
}
