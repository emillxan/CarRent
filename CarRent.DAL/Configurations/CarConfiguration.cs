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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            // Добавление внешнего ключа для связи с таблицей CarPhoto
            builder.HasMany(c => c.Photos)
                   .WithOne(cp => cp.Car)
                   .HasForeignKey(cp => cp.CarId);
            // Другие настройки, если нужно...
        }
    }
}
