using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;

namespace Golestan.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public void AddCourse(Course course)
        {
            InMemoryDB.Courses.Add(course);
        }

        public List<Course> GetCourses()
        {
            return InMemoryDB.Courses;
        }
    }
}
