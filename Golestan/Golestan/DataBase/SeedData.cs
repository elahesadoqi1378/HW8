using Golestan.Entities;

namespace Golestan.DataBase
{
    public static class SeedData
    {
        public static void Seed()
        {
            Operator op = new Operator("Admin", "Admin", "Admin@gmail.com");
            op.SetPassword("123456");
            op.ActivateUser();

            InMemoryDB.Users.Add(op);



            Teacher teacher = new Teacher("rasool", "yekta", "rasool.yekta@gmail.com");
            teacher.SetPassword("123456");
            teacher.ActivateUser();
            InMemoryDB.Users.Add(teacher);


            Student st = new Student("ela", "sdq", "ela@gmail.com");
            st.SetPassword("123456");
            st.ActivateUser();
            InMemoryDB.Users.Add(st);
        }


    }
}
