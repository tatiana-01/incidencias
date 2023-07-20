using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TrainerRepository : ITrainer
{
    private readonly IncidenciasContext _context;

    public TrainerRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(Trainer entity)
    {
        _context.Set<Trainer>().Add(entity);
    }

    public void AddRange(IEnumerable<Trainer> entities)
    {
        _context.Set<Trainer>().AddRange(entities);
    }

    public IEnumerable<Trainer> Find(Expression<Func<Trainer, bool>> expression)
    {
        return _context.Set<Trainer>().Where(expression);
    }

    public async Task<IEnumerable<Trainer>>? GetAllAsync()
    {
        return await _context.Set<Trainer>().ToListAsync();
    }

    public async Task<Trainer>? GetByIdAsync(string id)
    {
        return await _context.Trainers
        .Include(p => p.incidencias)
        .Include(p => p.telefonosTrainers)
        .Include(p => p.emailsTrainers)
        .FirstOrDefaultAsync(p => p.id == id);
    }

    public void Remove(Trainer entity)
    {
        _context.Set<Trainer>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Trainer> entities)
    {
        _context.Set<Trainer>().RemoveRange(entities);
    }

    public void Update(Trainer entity)
    {
        _context.Set<Trainer>().Update(entity);
    }
}
