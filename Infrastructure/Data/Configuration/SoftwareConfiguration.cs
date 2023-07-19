using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class SoftwareConfiguration : IEntityTypeConfiguration<Software>
{
    public void Configure(EntityTypeBuilder<Software> builder)
    {
        builder.ToTable("Softwares");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.descripcion)
            .HasMaxLength(150)
            .IsRequired();
            
            builder.HasOne(p=>p.tipoSoftware)
            .WithMany(p=>p.softwares)
            .HasForeignKey(p=>p.idTipoSoftware)
            .IsRequired();

            builder.HasOne(p=>p.puesto)
            .WithMany(p=>p.softwares)
            .HasForeignKey(p=>p.idPuesto)
            .IsRequired();

            builder.HasOne(p=>p.categoria)
            .WithMany(p=>p.softwares)
            .HasForeignKey(p=>p.idCategoria)
            .IsRequired();
    }
}

