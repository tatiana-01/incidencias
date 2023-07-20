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

public class EmailTrainerRepository : IEmailTrainer
{
    private readonly IncidenciasContext _context;

    public EmailTrainerRepository(IncidenciasContext context){
        _context = context;
    }
    public void Add(EmailTrainer entity)
    {
        _context.Set<EmailTrainer>().Add(entity);
    }

    public void AddRange(IEnumerable<EmailTrainer> entities)
    {
        _context.Set<EmailTrainer>().AddRange(entities);
    }

    public IEnumerable<EmailTrainer> Find(Expression<Func<EmailTrainer, bool>> expression)
    {
        return _context.Set<EmailTrainer>().Where(expression);
    }

    public async Task<IEnumerable<EmailTrainer>>? GetAllAsync()
    {
        return await _context.Set<EmailTrainer>().ToListAsync();
    }

    public async Task<EmailTrainer>? GetByIdAsync(int id)
    {
        return await _context.Set<EmailTrainer>().FindAsync(id);
    }

    public void Remove(EmailTrainer entity)
    {
        _context.Set<EmailTrainer>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<EmailTrainer> entities)
    {
        _context.Set<EmailTrainer>().RemoveRange(entities);
    }

    public void Update(EmailTrainer entity)
    {
        _context.Set<EmailTrainer>().Update(entity);
    }
}
