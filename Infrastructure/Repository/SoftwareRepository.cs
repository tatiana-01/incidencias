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

public class SoftwareRepository : ISoftware
{
    private readonly IncidenciasContext _context;

    public SoftwareRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(Software entity)
    {
        _context.Set<Software>().Add(entity);
    }

    public void AddRange(IEnumerable<Software> entities)
    {
        _context.Set<Software>().AddRange(entities);
    }

    public IEnumerable<Software> Find(Expression<Func<Software, bool>> expression)
    {
        return _context.Set<Software>().Where(expression);
    }

    public async Task<IEnumerable<Software>>? GetAllAsync()
    {
        return await _context.Set<Software>().ToListAsync();
    }

    public async Task<Software>? GetByIdAsync(int id)
    {
        return await _context.Set<Software>().FindAsync(id);
    }

    public void Remove(Software entity)
    {
        _context.Set<Software>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Software> entities)
    {
        _context.Set<Software>().RemoveRange(entities);
    }

    public void Update(Software entity)
    {
        _context.Set<Software>().Update(entity);
    }
}