using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;

namespace Golestan.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Result ActivateUser(int Id)
        {
            foreach (var users in GetInActiveUsers())
            {
                if(users.Id == Id)
                {
                    string output = users.ActivateUser();
                    return new Result(true, output);
                }
            }
            return new Result(false, "User Id is Incorrect.");
        }

        public User GetCurrentUser()
        {
            return InMemoryDB.CurrentUser ?? new User("test", "test", "test");
        }

        public List<User> GetInActiveUsers()
        {
            List<User> inActiveUsers = new List<User>();
            foreach (var item in InMemoryDB.Users)
            {
                if (item.IsActive == false)
                {
                    inActiveUsers.Add(item);                 
                }
            }
            return inActiveUsers;
        }

        public List<User> GetUsers()
        {
            return InMemoryDB.Users;
        }

        public void Login(User user)
        {
            InMemoryDB.CurrentUser = user;
        }

        public void Register(User user)
        {
            InMemoryDB.Users.Add(user);
        }
        public int LastStudentId()
        {
            int id = 0;
            foreach (var user in InMemoryDB.Users)
            {
                if (user is Student)
                {
                    id = user.Id;
                }
            }
            return id;
        }
    }
}
