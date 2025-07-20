using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _myDbConnection;

        public TeacherRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }
        public List<Teacher> GetAllTeachers()
        {

            //•	The commented code uses LINQ query syntax:
            List<Teacher> teachers = (from Teacher teacherObj in _myDbConnection.Teachers
                                      select teacherObj).ToList();

            // •	The uncommented code uses LINQ method syntax:
            //List<Teacher> teachers = _myDbConnection.Teachers.ToList();
            return teachers;

        }
        public void Create(Teacher teacher)
        {
            _myDbConnection.Teachers.Add(teacher);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = (from teacherObj in _myDbConnection.Teachers
                               where teacherObj.TeacherId == id
                               select teacherObj).FirstOrDefault();
            
            //Teacher teacher = _myDbConnection.Teachers.Find(id);
            
            _myDbConnection.Teachers.Remove(teacher);
            _myDbConnection.SaveChanges();
        }


    }
}
