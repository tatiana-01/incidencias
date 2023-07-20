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
    public DbSet<Categoria> ? Categorias {get; set;}
    public DbSet<Email> ? Emails {get; set;}
    public DbSet<EmailTrainer> ? EmailsTrainers {get; set;}
    public DbSet<Hardware> ? Hardwares {get; set;}
    public DbSet<Incidencia> ? Incidencias {get; set;}
    public DbSet<Puesto> ? Puestos {get; set;}
    public DbSet<Salon> ? Salones {get; set;}
    public DbSet<Software> ? Softwares {get; set;}
    public DbSet<Telefono> ? Telefonos {get; set;}
    public DbSet<TelefonoTrainer> ? TelefonosTrainers {get; set;}
    public DbSet<TipoHardware> ? TiposHardwares {get; set;}
    public DbSet<TipoIncidencia> ? TiposIncidencias {get; set;}
    public DbSet<TipoSoftware> ? TiposSoftwares {get; set;}
    public DbSet<Trainer> ? Trainers {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailTrainer>().HasKey(p=> new {p.idTrainer, p.idEmail});
        modelBuilder.Entity<TelefonoTrainer>().HasKey(p=> new {p.idTrainer, p.idTelefono});
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
