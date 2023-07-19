using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TelefonoConfiguration : IEntityTypeConfiguration<Telefono>
{
    public void Configure(EntityTypeBuilder<Telefono> builder)
    {
          builder.ToTable("Telefonos");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.tipo)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.descripcion)
            .HasMaxLength(50)
            .IsRequired();
    }
}
