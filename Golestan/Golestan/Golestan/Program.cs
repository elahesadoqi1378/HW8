using Golestan.DataBase;
using Golestan.Entities;
using Golestan.Enums;
using Golestan.Repositories;
using Golestan.Services;

Console.WriteLine("Wellcom To Golestan.");
CourseService courseService = new CourseService();
UserService userService = new UserService();    
SeedData.Seed();
MainMenu();




void MainMenu()
{
    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("        Main Menu");
    Console.WriteLine("********************");
    Console.Write("Please Select Your Action (1:Register , 2:Login) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action Is Invalid.");
        MainMenu();
    }
    switch (actionId)
    {
        case 1:
            Register();
            break;
        case 2:
            Login();
            break;
        default:
            Console.WriteLine("Selected Action Is Invalid.");
            MainMenu();
            break;
    }
}
void EntekhabVahedMenu()
{
    if (InMemoryDB.CurrentUser == null || InMemoryDB.CurrentUser is not Student)
    {
        Console.WriteLine("Please Login.");
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }


    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("        Student Menu");
    Console.WriteLine("********************");

    Console.WriteLine("****************** Selected Courses *******************");
    UserService userSer = new UserService();
    Student currentUser = (Student)userSer.GetCurrentUser();
    foreach (var course in currentUser.Courses)
    {
        Console.WriteLine(course);
    }
    Console.WriteLine("****************** Selected Courses *******************");

    Console.WriteLine("****************** Accessible Courses *******************");
    CourseService courseService = new CourseService();
    var courses = courseService.GetCourses();
    foreach (var course in courses)
    {
        Console.WriteLine(course);
    }
    Console.WriteLine("****************** Accessible Courses *******************");
    Console.Write("Please Select Your Course Id : ");
    var selectedCourseId = Int32.Parse(Console.ReadLine());
    var res = userService.EntekhabVahed(selectedCourseId,currentUser);
    Console.WriteLine(res.Message);
    EntekhabVahedMenu();

   
}

void StudentMenu()
{
    if (InMemoryDB.CurrentUser == null || InMemoryDB.CurrentUser is not Student)
    {
        Console.WriteLine("Please Login.");
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }


    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("        Student Menu");
    Console.WriteLine("********************");
    Console.Write("Please Select Your Action (1:ChangePass , 2:EntekhabVahed , 3:LogOut , 4:List of courses) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action Is Invalid.");
        StudentMenu();
    }

    switch (actionId)
    {
        case 1:
            Console.Write("Please Enter Your Current Password: ");
            var currentPass = Console.ReadLine();
            Console.Write("Please Enter Your New Password: ");
            var newPass = Console.ReadLine();
            Student st = (Student)InMemoryDB.CurrentUser;
            var result = st.ChangePassword(currentPass, newPass);

            Console.WriteLine(result.Message);
            Console.Write("Press Any Key To Continiue:");
            Console.ReadLine();
            StudentMenu();
            break;
        case 2:
            EntekhabVahedMenu();
            break;
        case 3:
            InMemoryDB.CurrentUser = null;
            MainMenu();
            break;
        case 4:
            Console.WriteLine("**********Courses**********");
            courseService.ListOfcourses();
            Console.WriteLine("***************************");
            Console.Write("Press Any Key To Continiue:");
            Console.ReadLine();
            StudentMenu();
            break;
        default:
            break;
    }
}
void OperatorMenu()
{
    if (InMemoryDB.CurrentUser == null || InMemoryDB.CurrentUser is not Operator)
    {
        Console.WriteLine("Please Login.");
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }


    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("        Operator Menu");
    Console.WriteLine("********************");
    Console.Write("Please Select Your Action (1:ChangePass , 2:Activate Users , 3: Add Course , 4:LogOut) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action Is Invalid.");
        StudentMenu();
    }

    switch (actionId)
    {
        case 1:
            Console.Write("Please Enter Your Current Password: ");
            var currentPass = Console.ReadLine();
            Console.Write("Please Enter Your New Password: ");
            var newPass = Console.ReadLine();
            Operator op = (Operator)InMemoryDB.CurrentUser;
            var result = op.ChangePassword(currentPass, newPass);

            Console.WriteLine(result.Message);
            Console.Write("Press Any Key To Continiue:");
            Console.ReadLine();
            OperatorMenu();

            break;
        case 2:
            break;
        case 3:

            //Console.Write("Please Enter Course Id: ");
            //var courseId = Int32.Parse( Console.ReadLine());
            Console.Write("Please Enter Course Name: ");
            var courseName = Console.ReadLine();
            Console.Write("Please Enter Course Unit: ");
            var courseUnit = Int32.Parse( Console.ReadLine());
            Console.WriteLine("Please enter the day of class: ");
            Console.WriteLine("1.saturday");
            Console.WriteLine("2.Sunday");
            Console.WriteLine("3.Monday");
            Console.WriteLine("4.Tuesday");
            Console.WriteLine("5.Wednesday");
            Console.WriteLine("6.Thursday");
            var courseDay =int.Parse( Console.ReadLine());
            DayOfWeek day = DayOfWeek.Monday;
            Console.WriteLine("please enter start time");
            int startTime =int.Parse( Console.ReadLine());
            TimeOnly sTime = new TimeOnly(startTime);
            Console.WriteLine("please enter end time");
            int endTime = int.Parse(Console.ReadLine());
            TimeOnly eTime = new TimeOnly(endTime);
            Console.WriteLine("please enter capacity of course");
            int capacity = int.Parse(Console.ReadLine());
            switch (courseDay)
            {
                case 1:
                    day = DayOfWeek.Saturday;
                    break;
                case 2:
                    day = DayOfWeek.Sunday;
                    break;
                case 3:
                    day = DayOfWeek.Monday;
                    break;
                case 4:
                    day = DayOfWeek.Tuesday;
                    break;
                case 5:
                    day = DayOfWeek.Wednesday;
                    break;
                case 6:
                    day = DayOfWeek.Thursday;
                    break;

                   
                default:
                    break;
            }
            Console.WriteLine();

            Course course = new Course(courseName,courseUnit,capacity,day,sTime,eTime);
            course.Id = InMemoryDB.CountCourseId++;
            InMemoryDB.CountCourseId++;
;
            userService.ListOfTeachers();
            Console.WriteLine("please enter your teacher by her id");
            int id = int.Parse(Console.ReadLine());

            CourseService courseService = new CourseService();
            courseService.SetCourse(course , id);
            OperatorMenu();

            break;
        case 4:
            InMemoryDB.CurrentUser = null;
            MainMenu();
            break;
        default:
            break;
    }
}
void TeacherMenu()
{
    if (InMemoryDB.CurrentUser == null)
    {
        Console.WriteLine("Please Login.");
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }
    if (InMemoryDB.CurrentUser != null && InMemoryDB.CurrentUser is not Teacher)
    {
        Console.WriteLine("Access Denid.");
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }


    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("        Teacher Menu");
    Console.WriteLine("********************");
    Console.Write("Please Select Your Action (1:ChangePass , 2:Activate Users , 3: Add Course , 4:LogOut) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action Is Invalid.");
        StudentMenu();
    }


}

void Login()
{
    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("        Login");
    Console.WriteLine("********************");
    Console.Write("Please Select Your Role (1:Student , 2:Operator , 3:Teacher) : ");

    if (!Int32.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Selected Role Is Invalid.");
        Login();
    }
    RoleEnum role = (RoleEnum)roleId;
    Console.Write("Please Enter UserName: ");
    var userName = Console.ReadLine();
    Console.Write("Please Enter PassWord: ");
    var password = Console.ReadLine();

    UserService userService = new UserService();
    var result = userService.Login(userName, password);
    if (!result.IsSucces)
    {
        Console.Write(result.Message);
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }
    switch (role)
    {
        case RoleEnum.Student:
            StudentMenu();
            break;
        case RoleEnum.Operator:
            OperatorMenu();
            break;
        case RoleEnum.Teacher:
            TeacherMenu();
            break;
        default:
            break;
    }

}
void Register(string? message = null)
{

    Console.Clear();
    if (message != null)
    {
        Console.WriteLine(message);
    }
    Console.WriteLine("********************");
    Console.WriteLine("        Register");
    Console.WriteLine("********************");
    Console.Write("Please Select Your Role (1:Student , 2:Operator , 3:Teacher) : ");

    if (!Int32.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Selected Role Is Invalid.");
        Register();
    }
    RoleEnum role = (RoleEnum)roleId;
    Console.Write("Please Enter FirstName: ");
    var firstName = Console.ReadLine();
    Console.Write("Please Enter LastName: ");
    var lastName = Console.ReadLine();
    Console.Write("Please Enter Email: ");
    var email = Console.ReadLine();
    Console.Write("Please Enter PassWord: ");
    var password = Console.ReadLine();

    UserService userService = new UserService();
    User user;
    switch (role)
    {
        case RoleEnum.Student:
            user = new Student(firstName, lastName, email);
            break;
        case RoleEnum.Operator:
            user = new Operator(firstName, lastName, email);
            break;
        case RoleEnum.Teacher:
            user = new Teacher(firstName, lastName, email);
            break;
        default:
            user = new User(firstName, lastName, email);
            break;
    }

    var result = userService.Register(user, password);
    if (!result.IsSucces)
    {
        Console.WriteLine(result.Message);
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Register();
    }
    else
    {
        Console.WriteLine("Registration is Success.");
        Console.Write("Press Any Key To Continiue:");
        Console.ReadLine();
        Login();
    }
}
