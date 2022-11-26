using RosaryCrusadeAPI.Data;
using RosaryCrusadeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RosaryCrusadeAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RosaryCrusadeAPIContext _context;

        public UserRepository(RosaryCrusadeAPIContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Add(user);
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.Where(iduser => iduser.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}