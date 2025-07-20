using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepoitory;
        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepoitory)
        {
            _courseRepository = courseRepository;
            _teacherRepoitory = teacherRepoitory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }
        [HttpGet]
        public ViewResult Create()
        {
            // Logic to render the creation view
            return View(_teacherRepoitory.GetAllTeachers());
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);
            }
            return View("Index",_courseRepository.GetAllCourses());
        }
        [HttpPost]
        public IActionResult Delete(int courseId)
        {
            _courseRepository.Delete(courseId);
            return View("Index",_courseRepository.GetAllCourses());
        }
    }

}
