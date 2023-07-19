using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmailTrainerConfiguration : IEntityTypeConfiguration<EmailTrainer>
{
    public void Configure(EntityTypeBuilder<EmailTrainer> builder)
    {
         builder.ToTable("EmailsTrainers");

            builder.HasOne(p=>p.trainer)
            .WithMany(p=>p.emailsTrainers)
            .HasForeignKey(p=>p.idTrainer);

            builder.HasOne(p=>p.email)
            .WithMany(p=>p.emailsTrainers)
            .HasForeignKey(p=>p.idEmail);

            builder.Property(p => p.trainerEmail)
            .HasMaxLength(50)
            .IsRequired();

            
    }
}
