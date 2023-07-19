using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoHardwareConfiguration : IEntityTypeConfiguration<TipoHardware>
{
    public void Configure(EntityTypeBuilder<TipoHardware> builder)
    {
         builder.ToTable("TiposHardware");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.nombreHardware)
            .HasMaxLength(50)
            .IsRequired();
    }
}
