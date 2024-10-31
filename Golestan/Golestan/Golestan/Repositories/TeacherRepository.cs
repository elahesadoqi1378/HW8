using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;

namespace Golestan.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public Teacher GetTeacher(int id)
        {
            foreach (var user in InMemoryDB.Users)
            {
                if (user.Id == id && user is Teacher)
                {
                    return (Teacher)user;
                }
            }
            return null;
        }

        public List<Teacher> GetTeachers()

        {
            List<Teacher> teachers = new List<Teacher>();
            foreach (var user in InMemoryDB.Users)
            {
                if (user is Teacher)
                {
                    teachers.Add((Teacher)user);
                }
            }
            return teachers;
        }

    }
}
