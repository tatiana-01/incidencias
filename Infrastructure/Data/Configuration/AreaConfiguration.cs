using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Areas");

            builder.Property(p => p.id)
            .IsRequired();

            builder.Property(p => p.nombreArea)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(p => p.descripcion)
            .IsRequired()
            .HasMaxLength(50);
        }
    }

