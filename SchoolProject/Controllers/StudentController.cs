using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.ViewModels;
using SchoolProject.Repository;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IHostingEnvironment _enviroment;

        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository,
            IHostingEnvironment enviroment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enviroment = enviroment;
        }
        // list of students
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = _studentRepository.GetAllStudents();

            return View(students);
        }

        // Render the creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student, IFormFile StudentPhoto)
        {
            var wwwrootPath = _enviroment.WebRootPath + "/StudentPictures/";

            Guid guid = Guid.NewGuid();

            string fullPath = System.IO.Path.Combine(wwwrootPath, guid + StudentPhoto.FileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                StudentPhoto.CopyTo(fileStream);
            };
            student.PhotoName = guid + StudentPhoto.FileName;
            if (student != null)
            {
                _studentRepository.Create(student);
            }
            return View("Index",_studentRepository.GetAllStudents());
        }

        [HttpPost]
        public IActionResult Delete(int StudentId)
        {
            _studentRepository.Delete(StudentId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Register()
        {
            StudentCourseVM studentCourseVM = new StudentCourseVM
            {

                Students = _studentRepository.GetAllStudents(),
                Courses = _courseRepository.GetAllCourses()
            };
            return View(studentCourseVM);
        }

        [HttpPost]
        public IActionResult Register(int studentId,int courseId)
        {   
            _studentRepository.Register(studentId, courseId);
            return RedirectToAction("Register");
        }
    }
}
