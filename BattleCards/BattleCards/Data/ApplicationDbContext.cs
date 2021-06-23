using System.Security.Cryptography.X509Certificates;
using BattleCards.Data.Models;

namespace BattleCards.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>()
                .HasKey(t => new { t.CardId, t.UserId });
        }
    }
}
