using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class IncidenciaConfiguration : IEntityTypeConfiguration<Incidencia>
{
    public void Configure(EntityTypeBuilder<Incidencia> builder)
    {
        builder.ToTable("Incidencias");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.descripcion)
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(p => p.fechaReporte)
            .HasColumnType("Date")
            .IsRequired();
            
            builder.HasOne(p=>p.tipoIncidencia)
            .WithMany(p=>p.incidencias)
            .HasForeignKey(p=>p.idTipoIncidencia)
            .IsRequired();

            builder.HasOne(p=>p.puesto)
            .WithMany(p=>p.incidencias)
            .HasForeignKey(p=>p.idPuesto)
            .IsRequired();

            builder.HasOne(p=>p.categoria)
            .WithMany(p=>p.incidencias)
            .HasForeignKey(p=>p.idCategoria)
            .IsRequired();

            builder.HasOne(p=>p.trainer)
            .WithMany(p=>p.incidencias)
            .HasForeignKey(p=>p.idTrainer)
            .IsRequired();
    }
}
