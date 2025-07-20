using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyDbContext _myDbConnection;

        public CourseRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }

        public List<Course> GetAllCourses()
        {
            // LINQ query syntax:
            List<Course> courses = (from courseObj in _myDbConnection.Courses
                                    select courseObj).ToList();

            // LINQ method syntax:
            // List<Course> courses = _myDbConnection.Courses.ToList();
            return courses;
        }

        public void Create(Course course)
        {
            _myDbConnection.Courses.Add(course);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Course? course = (from courseObj in _myDbConnection.Courses
                             where courseObj.CourseId == id
                             select courseObj).FirstOrDefault();

            // Course course = _myDbConnection.Courses.Find(id);

            if (course != null)
            {
                _myDbConnection.Courses.Remove(course);
                _myDbConnection.SaveChanges();
            }
        }
    }

}
