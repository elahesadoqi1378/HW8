using Golestan.Entities;

namespace Golestan.Contracts
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        List<Course> GetCourses();
        //List<Course> GetCourses();
    }
}
