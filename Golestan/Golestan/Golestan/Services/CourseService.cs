using Golestan.Contracts;
using Golestan.Entities;
using Golestan.Repositories;

namespace Golestan.Services
{
    public class CourseService
    {
        ICourseRepository _courseRepo;
        ITeacherRepository _teacherRepo;
        public CourseService()
        {
            _courseRepo = new CourseRepository();
            _teacherRepo = new TeacherRepository();
        }
        public void SetCourse(Course course , int id)
        {


            course.Teachers.Add(_teacherRepo.GetTeacher(id)); 
            _courseRepo.AddCourse(course);
        }

        public List<Course> GetCourses()
        {
            return _courseRepo.GetCourses();
        }
        public void ListOfcourses()
        {
            _courseRepo.GetCourses().ToList().ForEach(course => { Console.WriteLine("---------------------"); Console.WriteLine(course.ToString()); });
        }
        public void 
    }
}
