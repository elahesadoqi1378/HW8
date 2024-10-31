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

        public Course GetCourseById(int id)
        {
            foreach (var course in InMemoryDB.Courses)
            {
                if(course.Id == id)
                {
                    return course;
                }
            }
            return null;
        }

        public List<Course> GetCourses()
        {
            return InMemoryDB.Courses;
        }
    }
}
