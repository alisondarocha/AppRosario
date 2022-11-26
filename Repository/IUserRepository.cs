using RosaryCrusadeAPI.Models;

namespace RosaryCrusadeAPI.Repository
{
    public interface IUserRepository
    {
        void Register(User user);

        Task<User> Get(Guid id);

        Task<bool> SaveChangesAsync();
    }
}