using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TelefonoTrainerConfiguration : IEntityTypeConfiguration<TelefonoTrainer>
{
    public void Configure(EntityTypeBuilder<TelefonoTrainer> builder)
    {
        builder.ToTable("TelefonoTrainers");

            builder.HasOne(p=>p.trainer)
            .WithMany(p=>p.telefonosTrainers)
            .HasForeignKey(p=>p.idTrainer);

            builder.HasOne(p=>p.telefono)
            .WithMany(p=>p.telefonosTrainers)
            .HasForeignKey(p=>p.idTelefono);

            builder.Property(p => p.numeroTelefono)
            .HasMaxLength(50)
            .IsRequired();

    }
}
