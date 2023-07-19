using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
          builder.ToTable("Trainers");

            builder.Property(p => p.id)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(p => p.nombreCompleto)
            .HasMaxLength(150)
            .IsRequired();
    }
}
