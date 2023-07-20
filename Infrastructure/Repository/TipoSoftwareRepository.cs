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

public class TipoSoftwareRepository : ITipoSoftware
{
    private readonly IncidenciasContext _context;

    public TipoSoftwareRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(TipoSoftware entity)
    {
        _context.Set<TipoSoftware>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoSoftware> entities)
    {
        _context.Set<TipoSoftware>().AddRange(entities);
    }

    public IEnumerable<TipoSoftware> Find(Expression<Func<TipoSoftware, bool>> expression)
    {
        return _context.Set<TipoSoftware>().Where(expression);
    }

    public async Task<IEnumerable<TipoSoftware>>? GetAllAsync()
    {
        return await _context.Set<TipoSoftware>().ToListAsync();
    }

    public async Task<TipoSoftware>? GetByIdAsync(int id)
    {
        return await _context.TiposSoftwares
        .Include(p => p.softwares)
        .FirstOrDefaultAsync(p => p.id == id);
    }

    public void Remove(TipoSoftware entity)
    {
        _context.Set<TipoSoftware>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoSoftware> entities)
    {
        _context.Set<TipoSoftware>().RemoveRange(entities);
    }

    public void Update(TipoSoftware entity)
    {
        _context.Set<TipoSoftware>().Update(entity);
    }
}
