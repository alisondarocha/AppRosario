using AppRosario.Data;
using AppRosario.Models;

namespace AppRosario.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppRosarioContext _context;
        
        public UserRepository(AppRosarioContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Add(user);
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.Where(iduser => iduser.Id == id).FirstOrDefaultAsync();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}