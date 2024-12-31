using CarManagementApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApplication.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(e => e.Garages)
                .WithMany(e => e.Cars);
        }
    }
}