using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class TeacherController: Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository  = teacherRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Logic to get the list of teachers
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        [HttpGet]
        public ViewResult Create()
        {
            // Logic to render the creation view
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            // Logic to create a new teacher
            if (teacher != null)
            {
                _teacherRepository.Create(teacher);
                
            }
            return View("Index", _teacherRepository.GetAllTeachers());
        }
        [HttpPost]
        public IActionResult Delete(int teacherId)
        {
            // Logic to delete a teacher
            _teacherRepository.Delete(teacherId);
            return View("Index",_teacherRepository.GetAllTeachers());
        }
    }
}
