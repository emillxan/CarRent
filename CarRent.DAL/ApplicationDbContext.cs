using CarRent.DAL.Configurations;
using CarRent.Domain.Entity;
using CarRent.Domain.Enum;
using CarRent.Domain.Hepler;
using Microsoft.EntityFrameworkCore;

namespace CarRent.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 
            Database.EnsureCreated();
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarPhoto> CarPhoto { get; set; }
        public DbSet<Rental> Rental { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());
        }
    }
}
