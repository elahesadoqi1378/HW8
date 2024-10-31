using Golestan.Entities;

namespace Golestan.DataBase
{
    public static class InMemoryDB
    {
        public static User? CurrentUser { get; set; }
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Course> Courses { get; set; } = new List<Course>();
        public static int CountCourseId { get; set; } = 0;

    }
}
