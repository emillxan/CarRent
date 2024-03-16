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
    public class CarPhotoConfiguration : IEntityTypeConfiguration<CarPhoto>
    {
        public void Configure(EntityTypeBuilder<CarPhoto> builder)
        {
            builder.HasKey(cp => cp.Id);
            // Другие настройки, если нужно...
        }
    }
}
