using System.Xml.Linq;

namespace Golestan.Entities
{
    public class Teacher : User
    {
        public Teacher(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }

        public List<Course> Courses { get; set; } = new List<Course>();
        public override string ToString()
        {
            return $"{FirstName}-{LastName}-{Email}- id: {Id}";
        }
    }
}
