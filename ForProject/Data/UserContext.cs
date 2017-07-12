using ForProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ForProject.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<CreateUser> CreateUser { get; set; }
        public DbSet<UserLogIn> UserLogIn { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreateUser>().ToTable("CreateUser");
            modelBuilder.Entity<UserLogIn>().ToTable("UserLogIn");
        }
    }
}
