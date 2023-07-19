using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class HardwareConfiguration : IEntityTypeConfiguration<Hardware>
{
    public void Configure(EntityTypeBuilder<Hardware> builder)
    {
         builder.ToTable("Hardwares");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.descripcion)
            .HasMaxLength(150)
            .IsRequired();
            
            builder.HasOne(p=>p.tipoHardware)
            .WithMany(p=>p.hardwares)
            .HasForeignKey(p=>p.idTipoHardware)
            .IsRequired();

            builder.HasOne(p=>p.puesto)
            .WithMany(p=>p.hardwares)
            .HasForeignKey(p=>p.idPuesto)
            .IsRequired();

            builder.HasOne(p=>p.categoria)
            .WithMany(p=>p.hardwares)
            .HasForeignKey(p=>p.idTipoHardware)
            .IsRequired();
    }
}
