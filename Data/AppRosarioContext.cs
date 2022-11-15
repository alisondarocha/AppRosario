using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppRosario.Models;

namespace AppRosario.Data
{
    public class AppRosarioContext : DbContext
    {
        public DbSet<User> Users { get; set;}

        public AppRosarioContext(DbContextOptions<AppRosarioContext> options) : base(options)
        {

        }
    }
}