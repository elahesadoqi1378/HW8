using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;

namespace Golestan.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetCurrentUser()
        {
            return InMemoryDB.CurrentUser ?? new User("test", "test", "test");
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
    }
}
