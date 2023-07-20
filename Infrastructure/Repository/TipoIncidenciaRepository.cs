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

public class TipoIncidenciaRepository : ItipoIncidencia
{
    private readonly IncidenciasContext _context;

    public TipoIncidenciaRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(TipoIncidencia entity)
    {
        _context.Set<TipoIncidencia>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoIncidencia> entities)
    {
        _context.Set<TipoIncidencia>().AddRange(entities);
    }

    public IEnumerable<TipoIncidencia> Find(Expression<Func<TipoIncidencia, bool>> expression)
    {
        return _context.Set<TipoIncidencia>().Where(expression);
    }

    public async Task<IEnumerable<TipoIncidencia>>? GetAllAsync()
    {
        return await _context.Set<TipoIncidencia>().ToListAsync();
    }

    public async Task<TipoIncidencia>? GetByIdAsync(int id)
    {
        return await _context.TiposIncidencias
        .Include(p => p.incidencias)
        .FirstOrDefaultAsync(p => p.id == id);
    }

    public void Remove(TipoIncidencia entity)
    {
        _context.Set<TipoIncidencia>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoIncidencia> entities)
    {
        _context.Set<TipoIncidencia>().RemoveRange(entities);
    }

    public void Update(TipoIncidencia entity)
    {
        _context.Set<TipoIncidencia>().Update(entity);
    }
}
