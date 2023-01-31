using RosaryCrusadeAPI.Models;

namespace RosaryCrusadeAPI.Repository
{
    public interface IUserRepository
    {
        void Register(User user);

        void DeleteUser(User user);

        Task<User> GetUser(Guid id); 

        User Get(string email, string password);

        Task<bool> SaveChangesAsync();
    }
}