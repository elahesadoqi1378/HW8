using Golestan.Entities;

namespace Golestan.Contracts
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void Login(User user);
        void Register(User user);

        User GetCurrentUser();
    }
}
