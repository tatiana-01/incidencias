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

public class TelefonoTrainerRepository : ITelefonoTrainer
{
    private readonly IncidenciasContext _context;

    public TelefonoTrainerRepository(IncidenciasContext context)
    {
        _context = context;
    }
    public void Add(TelefonoTrainer entity)
    {
        _context.Set<TelefonoTrainer>().Add(entity);
    }

    public void AddRange(IEnumerable<TelefonoTrainer> entities)
    {
        _context.Set<TelefonoTrainer>().AddRange(entities);
    }

    public IEnumerable<TelefonoTrainer> Find(Expression<Func<TelefonoTrainer, bool>> expression)
    {
        return _context.Set<TelefonoTrainer>().Where(expression);
    }

    public async Task<IEnumerable<TelefonoTrainer>>? GetAllAsync()
    {
        return await _context.Set<TelefonoTrainer>().ToListAsync();
    }

    public async Task<TelefonoTrainer>? GetByIdAsync(string idTrainer, int idTelefono)
    {
        return await _context.TelefonosTrainers
        .FirstOrDefaultAsync(p=>(p.idTrainer == idTrainer && p.idTelefono == idTelefono) );
    }

    public void Remove(TelefonoTrainer entity)
    {
        _context.Set<TelefonoTrainer>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TelefonoTrainer> entities)
    {
        _context.Set<TelefonoTrainer>().RemoveRange(entities);
    }

    public void Update(TelefonoTrainer entity)
    {
        _context.Set<TelefonoTrainer>().Update(entity);
    }
}
