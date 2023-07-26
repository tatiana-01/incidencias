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

public class AreaRepository : IArea
{
    private readonly IncidenciasContext _context;

    public AreaRepository(IncidenciasContext context){
        _context = context;
    }
    public void Add(Area entity)
    {
        _context.Set<Area>().Add(entity);
    }

    public void AddRange(IEnumerable<Area> entities)
    {
        _context.Set<Area>().AddRange(entities);
    }

    public IEnumerable<Area> Find(Expression<Func<Area, bool>> expression)
    {
        return _context.Set<Area>().Where(expression);
    }

    public async Task<IEnumerable<Area>>? GetAllAsync()
    {
        return await _context.Set<Area>()
        .ToListAsync();
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Areas as IQueryable<Area>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p=>p.nombreArea.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(u=>u.salones)
            .Skip((pageIndex-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<Area>>? GetAllAsyncV11()
    {
        return await _context.Set<Area>()
        .Include(p=>p.salones)
        .ToListAsync();
    }

    public async Task<Area>? GetByIdAsync(int id)
    {
        return await _context.Areas
        .Include(p=>p.salones)
        .FirstOrDefaultAsync(p=>p.id == id);
    }

    public void Remove(Area entity)
    {
        _context.Set<Area>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Area> entities)
    {
        _context.Set<Area>().RemoveRange(entities);
    }

    public void Update(Area entity)
    {
        _context.Set<Area>().Update(entity);
    }
}
