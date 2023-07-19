using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PuestoConfiguration : IEntityTypeConfiguration<Puesto>
{
    public void Configure(EntityTypeBuilder<Puesto> builder)
    {
         builder.ToTable("Puestos");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.nombrePuesto)
            .HasMaxLength(50)
            .IsRequired();
            
            builder.HasOne(p=>p.salon)
            .WithMany(p=>p.puestos)
            .HasForeignKey(p=>p.idSalon)
            .IsRequired();
    }
}
