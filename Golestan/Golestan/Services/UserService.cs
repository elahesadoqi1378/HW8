using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;
using Golestan.Enums;
using Golestan.Repositories;

namespace Golestan.Services
{
    public class UserService
    {
        ICourseRepository courseRep = new CourseRepository();
        IUserRepository userRep = new UserRepository();
        ITeacherRepository teacherRep = new TeacherRepository();
        public Result Login(string userName, string password)
        {

            var users = userRep.GetUsers();
            foreach (var user in users)
            {
                if (user.UserName == userName)
                {
                    var res = user.CheckPassword(password);
                    if (res.IsSucces)
                    {
                        if (user.IsActive)
                        {
                            userRep.Login(user);
                            return new Result(true);
                        }
                        else
                        {
                            return new Result(false, "User is InActive.");
                        }
                    }
                    else
                    {
                        return new Result(false, "Password Is Invalid.");
                    }
                }
            }
            return new Result(false, "User Not Found.");
        }

        public Result Register(User user, string pass)
        {
            var result = user.SetPassword(pass);

            if (result.IsSucces)
            {
                userRep.Register(user);
                return new Result(true);
            }
            else
            {
                return result;
            }
        }

        public User GetCurrentUser()
        {
            return userRep.GetCurrentUser();
        }
        public Result EntekhabVahed(int idcourse, Student user)
        {
            if (user.IsActive)
            {
                Course course = courseRep.GetCourseById(idcourse);
                foreach (var Course in user.Courses)
                {
                    if (idcourse == Course.Id)
                    {
                        return new Result(false, "You Already take this course!");
                    }
                }
                foreach (var Course in user.Courses)
                {
                    if (Course.Day == course.Day)
                    {
                        if (course.EndTime < Course.EndTime && course.EndTime > Course.StartTime)
                        {
                            return new Result(false, "Interference time!");
                        }
                        if (course.StartTime < Course.EndTime && course.StartTime > Course.StartTime)
                        {
                            return new Result(false, "Interference time!");
                        }
                    }
                }
                foreach (var item in InMemoryDB.Courses)
                {
                    if (item.Id == idcourse)
                    {
                        int a = item.Unit + user.UnitSum();
                        if (a < 20 || a > 12)
                        {
                            user.Courses.Add(item);
                            item.Students.Add(user);
                            return new Result(true);
                        }
                        else
                        {
                            return new Result(false, "you Can not! it is more than capacity!");
                        }
                    }

                }
            }
            return new Result(false, "incorrect id.");
        }
        public Result ListOfTeachers()
        {
            var t = teacherRep.GetTeachers();
            if (t != null)
            {
                foreach (var te in t)
                {
                    Console.WriteLine(te.ToString());
                    return new Result(true);
                }
            }
            return new Result(false, "No teacher found");
        }

        public Result ListInActiveUsers()
        {
            if (userRep.GetInActiveUsers() != null)
            {
                foreach (var inActiveUser in userRep.GetInActiveUsers())
                {
                    Console.WriteLine("********************");
                    Console.WriteLine(inActiveUser.ToString());
                }
                return new Result(true);
            }
            return new Result(false, "No InActive User Found.");
        }
        public string ActivateUser(int Id)
        {
            var result = userRep.ActivateUser(Id);
            return result.Message;
        }
        public void StudentCourse(Student st)
        {
            if(st.Courses != null)
            {
                foreach (var course in st.Courses)
                {
                    Console.WriteLine(course.ToString());
                }
            }
            else
            {
                Console.WriteLine("course is empty");
            }
            
        }
        public void SetStuId(Student St)
        {
            int id = userRep.LastStudentId();
            St.Id = id + 1;
        }
    }
}
