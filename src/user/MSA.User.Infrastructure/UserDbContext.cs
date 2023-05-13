using Microsoft.EntityFrameworkCore;

namespace MSA.User.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("user");

            modelBuilder.Entity<Domain.User>(user =>
            {
                user.HasKey(x => x.Id);
            });
        }
    }
}
