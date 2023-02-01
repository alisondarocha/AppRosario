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

        public async Task<User> GetUser (Guid id)
        {
            return await _context.Users.Where(idUser => idUser.Id == id).FirstOrDefaultAsync();
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public User Get(string email, string password)
        {
            return _context.Users.Where(pass => pass.Password.ToLower() == password.ToLower() && pass.Email == email).FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}