using AppRosario.Models;

namespace AppRosario.Repository
{
    public interface IUserRepository
    {
        void Register (User user);

        Task <User> Get(int id);

        void Delete (User user);
        
        Task<bool> SaveChangesAsync();
    }
}