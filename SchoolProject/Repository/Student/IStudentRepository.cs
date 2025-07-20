using SchoolProject.Models;


namespace SchoolProject.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Models.Student student);
        public void Delete(int id);
        public void Register(int studentId, int courseId);
    }
}
