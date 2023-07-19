using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
         builder.ToTable("Emails");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.tipoEmail)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.descripcion)
            .HasMaxLength(50)
            .IsRequired();
    }
}
