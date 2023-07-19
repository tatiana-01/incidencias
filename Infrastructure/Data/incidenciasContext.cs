using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class IncidenciasContext : DbContext
{
    public IncidenciasContext(DbContextOptions<IncidenciasContext> options) : base(options)
    {
    }
    public DbSet<Area> ? Areas {get; set;}
    //public DbSet<Trainer> ? Trainers {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
