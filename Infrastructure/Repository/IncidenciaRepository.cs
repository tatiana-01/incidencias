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

public class IncidenciaRepository : IIncidencia
{
    private readonly IncidenciasContext _context;

    public IncidenciaRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(Incidencia entity)
    {
        _context.Set<Incidencia>().Add(entity);
    }

    public void AddRange(IEnumerable<Incidencia> entities)
    {
        _context.Set<Incidencia>().AddRange(entities);
    }

    public IEnumerable<Incidencia> Find(Expression<Func<Incidencia, bool>> expression)
    {
        return _context.Set<Incidencia>().Where(expression);
    }

    public async Task<IEnumerable<Incidencia>>? GetAllAsync()
    {
        return await _context.Set<Incidencia>().ToListAsync();
    }

    public async Task<Incidencia>? GetByIdAsync(int id)
    {
        return await _context.Set<Incidencia>().FindAsync(id);
    }

    public void Remove(Incidencia entity)
    {
        _context.Set<Incidencia>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Incidencia> entities)
    {
        _context.Set<Incidencia>().RemoveRange(entities);
    }

    public void Update(Incidencia entity)
    {
        _context.Set<Incidencia>().Update(entity);
    }
}
