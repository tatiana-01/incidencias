using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoSoftwareConfiguration : IEntityTypeConfiguration<TipoSoftware>
{
    public void Configure(EntityTypeBuilder<TipoSoftware> builder)
    {
        builder.ToTable("TiposSoftware");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.nombreSoftware)
            .HasMaxLength(50)
            .IsRequired();
    }
}
