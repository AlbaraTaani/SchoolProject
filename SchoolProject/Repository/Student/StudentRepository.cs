using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _myDbConnection;

        public StudentRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdsObj in _myDbConnection.Students
                                          select stdsObj).ToList();
                return students;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public void Create(Student student)
        {
            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Student? student = _myDbConnection.Students.Find(id);

                if (student != null)
                {
                    _myDbConnection.Students.Remove(student);
                    _myDbConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Register(int studentId, int courseId)
        {
            //StudentCourse studentCourse = new StudentCourse
            //{
            //    StudentId = studentId,
            //    CourseId = courseId
            //};
            //_myDbConnection.StudentCourses.Add(studentCourse);


            // alternative way to add a student to a course

            _myDbConnection.StudentCourses.Add(new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            });
            _myDbConnection.SaveChanges();
        }
    }
}
