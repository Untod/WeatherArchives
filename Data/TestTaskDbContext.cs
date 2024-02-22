using Microsoft.EntityFrameworkCore;
using TestTask_DynamicSun.Models;

namespace TestTask_DynamicSun.Data
{
    public class TestTaskDbContext : DbContext
    {
        public TestTaskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeatherDetails> WeatherDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WeatherDetails>()
                .HasIndex(x => x.Date)
                .IsUnique();
        }
    }
}
