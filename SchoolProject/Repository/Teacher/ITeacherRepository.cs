using SchoolProject.Models;


namespace SchoolProject.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);
        public void Delete(int id);
        //public Teacher GetTeacherById(int id);
        //public void Update(Teacher teacher);
    }
}
