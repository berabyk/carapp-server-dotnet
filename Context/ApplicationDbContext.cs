using CarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
            
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Light> Lights { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-one relationship
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Light)
                .WithOne(l => l.Car)
                .HasForeignKey<Light>(l => l.CarId);
        }
    }
}
