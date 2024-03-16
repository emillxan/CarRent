using CarRent.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(r => r.Id);
            // Добавление внешних ключей для связей с таблицами Car и User
            builder.HasOne(r => r.Car)
                   .WithMany(c => c.Rentals)
                   .HasForeignKey(r => r.CarId);
            builder.HasOne(r => r.User)
                   .WithMany(u => u.Rentals)
                   .HasForeignKey(r => r.UserId);
            // Другие настройки, если нужно...
        }
    }
}
