using CarRent.Domain.Entity;
using CarRent.Domain.Enum;
using CarRent.Domain.Hepler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Users> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new Users
                {
                    Id = 1,
                    FirstName = "emil",
                    SecondName = "xan",
                    eMail = "emilxan@gmail.com",
                    Password = HashPasswordHelper.HashPassowrd("emil1234"),
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
                builder.Property(x => x.SecondName).HasMaxLength(100).IsRequired();
                builder.Property(x => x.eMail).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<Users>(x => x.Id)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profile").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(250);
                builder.Property(x => x.UserId);
            });
        }
    }
}
