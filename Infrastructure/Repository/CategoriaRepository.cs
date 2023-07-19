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

public class CategoriaRepository : ICategoria
{
    private readonly IncidenciasContext _context;

    public CategoriaRepository(IncidenciasContext context){
        _context = context;
    }
    public void Add(Categoria entity)
    {
        _context.Set<Categoria>().Add(entity);
    }

    public void AddRange(IEnumerable<Categoria> entities)
    {
        _context.Set<Categoria>().AddRange(entities);
    }

    public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> expression)
    {
        return _context.Set<Categoria>().Where(expression);
    }

    public async Task<IEnumerable<Categoria>>? GetAllAsync()
    {
        return await _context.Set<Categoria>().ToListAsync();
    }

    public async Task<Categoria>? GetByIdAsync(int id)
    {
        return await _context.Categorias
        .Include(p=>p.incidencias)
        .Include(p=>p.hardwares)
        .Include(p=>p.softwares)
        .FirstOrDefaultAsync(p=>p.id == id);
    }

    public void Remove(Categoria entity)
    {
        _context.Set<Categoria>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Categoria> entities)
    {
        _context.Set<Categoria>().RemoveRange(entities);
    }

    public void Update(Categoria entity)
    {
        _context.Set<Categoria>().Update(entity);
    }
}
