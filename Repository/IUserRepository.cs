using AppRosario.Models;

namespace AppRosario.Repository
{
    public interface IUserRepository
    {
        void Register (User user);

        Task <User> Get(int id);
        
        Task<bool> SaveChangesAsync();
    }
}