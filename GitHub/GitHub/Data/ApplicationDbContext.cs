using GitHub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Commit> Commits { get; set; }

        public DbSet<Repository> Repositories { get; set; }

        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=GitHub;Integrated Security=True;");
            }
        }
    }
}
