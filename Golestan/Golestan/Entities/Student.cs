using Golestan.Enums;
using System.Xml.Linq;

namespace Golestan.Entities
{
    public class Student : User
    {
        public int StudentNO { get; private set; }
        public int Age { get; set; }
        public StudentStatusEnum Status { get; private set; }
        public GenderEnum Gender { get; set; }
        public bool IsMashroot { get; private set; }
        public bool IsMomtaz { get; private set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public Student(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
            Status = StudentStatusEnum.Inactive;
        }
        public Student(string firstName, string lastName, string email , int studentNO , int age , GenderEnum gender) : this(firstName, lastName, email)
        {
            StudentNO = studentNO;
            Gender = gender;
            Age=age;       
        }
        public override Result ChangePassword(string currentPass, string newPass)
        {
            if (currentPass == Password)
            {
                return SetPassword(newPass);
            }
            else
            {
                return new Result(false, "Current Pass Is InCorrect.");
            }
        }
        public override Result SetPassword(string pass)
        {
            if (!string.IsNullOrEmpty(pass) && pass.Length >= 6)
            {
                Password = pass;
                return new Result(true, null);
            }
            else
                return new Result(false, "Password Is Incorrect.");
        }
        public string Activate()
        {
            if (Status == StudentStatusEnum.Active)
                return "Student Already Actived";
            if (Status == StudentStatusEnum.Suspend)
                return "Cannot Active Student.";
            Status = StudentStatusEnum.Active;
            return "Student Actived Successfully.";
        }
        public string SetMashroot()
        {
            IsMashroot = true;
            return "Success";
        }
        public string SetMomtaz()
        {
            IsMomtaz = true;
            return "Success";
        }
        public int UnitSum()
        {
            int unit = 0;
            foreach(var item in Courses)
            {
                unit += item.Unit;
                return unit;
            }
            return 0;
         }
        public override string ToString()
        {
            return $"{FirstName}-{LastName}-{Email}- id: {Id}- Gender: {Gender}- Age: {Age}- Status: {Status}";
        }
    }
}
