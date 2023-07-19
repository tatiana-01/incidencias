using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class SalonConfiguration : IEntityTypeConfiguration<Salon>
{
    public void Configure(EntityTypeBuilder<Salon> builder)
    {
         builder.ToTable("Salones");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.nombreSalon)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(p => p.numeroPuestos)
            .IsRequired();
            
            builder.HasOne(p=>p.area)
            .WithMany(p=>p.salones)
            .HasForeignKey(p=>p.idArea)
            .IsRequired();
    }
}
