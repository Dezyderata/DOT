using Microsoft.EntityFrameworkCore;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Infrastructure.Context
{
    public class WeightWatcherContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
        
        
        public WeightWatcherContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.WeightWatcherApi.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Measurements)
                .WithOne(y => y.User)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();

        }
    }
}