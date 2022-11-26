using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RosaryCrusadeAPI.Models;

namespace RosaryCrusadeAPI.Data
{
    public class RosaryCrusadeAPIContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public RosaryCrusadeAPIContext(DbContextOptions<RosaryCrusadeAPIContext> options) : base(options)
        {

        }
    }
}