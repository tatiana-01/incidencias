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

public class TipoHardwareRepository : ITipoHardware
{
    private readonly IncidenciasContext _context;

    public TipoHardwareRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(TipoHardware entity)
    {
        _context.Set<TipoHardware>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoHardware> entities)
    {
        _context.Set<TipoHardware>().AddRange(entities);
    }

    public IEnumerable<TipoHardware> Find(Expression<Func<TipoHardware, bool>> expression)
    {
        return _context.Set<TipoHardware>().Where(expression);
    }

    public async Task<IEnumerable<TipoHardware>>? GetAllAsync()
    {
        return await _context.Set<TipoHardware>().ToListAsync();
    }

    public async Task<TipoHardware>? GetByIdAsync(int id)
    {
        return await _context.TiposHardwares
        .Include(p=>p.hardwares)
        .FirstOrDefaultAsync(p=>p.id == id);
    }

    public void Remove(TipoHardware entity)
    {
        _context.Set<TipoHardware>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoHardware> entities)
    {
        _context.Set<TipoHardware>().RemoveRange(entities);
    }

    public void Update(TipoHardware entity)
    {
        _context.Set<TipoHardware>().Update(entity);
    }
}
