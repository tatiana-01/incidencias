using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoIncidenciaConfiguration : IEntityTypeConfiguration<TipoIncidencia>
{
    public void Configure(EntityTypeBuilder<TipoIncidencia> builder)
    {
          builder.ToTable("TipoIncidencia");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.NivelIncidencia)
            .HasMaxLength(50)
            .IsRequired();
    }
}
