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

public class SalonRepository : ISalon
{
    private readonly IncidenciasContext _context;

    public SalonRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(Salon entity)
    {
        _context.Set<Salon>().Add(entity);
    }

    public void AddRange(IEnumerable<Salon> entities)
    {
        _context.Set<Salon>().AddRange(entities);
    }

    public IEnumerable<Salon> Find(Expression<Func<Salon, bool>> expression)
    {
        return _context.Set<Salon>().Where(expression);
    }

    public async Task<IEnumerable<Salon>>? GetAllAsync()
    {
        return await _context.Set<Salon>().ToListAsync();
    }

    public async Task<Salon>? GetByIdAsync(int id)
    {
        return await _context.Salones
        .Include(p=>p.puestos)
        .FirstOrDefaultAsync(p=>p.id == id);
    }

    public void Remove(Salon entity)
    {
        _context.Set<Salon>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Salon> entities)
    {
        _context.Set<Salon>().RemoveRange(entities);
    }

    public void Update(Salon entity)
    {
        _context.Set<Salon>().Update(entity);
    }
}
