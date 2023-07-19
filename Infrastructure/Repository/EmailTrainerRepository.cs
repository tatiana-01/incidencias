using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class EmailTrainerRepository : IEmailTrainer
{
    private readonly IncidenciasContext _context;

    public EmailTrainerRepository(IncidenciasContext context){
        _context = context;
    }
    public void Add(EmailTrainer entity)
    {
        _context.Set<Email>().Add(entity);
    }

    public void AddRange(IEnumerable<EmailTrainer> entities)
    {
        _context.Set<Email>().AddRange(entities);
    }

    public IEnumerable<EmailTrainer> Find(Expression<Func<EmailTrainer, bool>> expression)
    {
        return _context.Set<Email>().Where(expression);
    }

    public Task<IEnumerable<EmailTrainer>>? GetAllAsync()
    {
        return await _context.Set<Email>().ToListAsync();
    }

    public Task<EmailTrainer>? GetByIdAsync(int id)
    {
        return await _context.Emails
        .Include(p=>p.emailsTrainers)
        .FirstOrDefaultAsync(p=>p.id == id);
    }

    public void Remove(EmailTrainer entity)
    {
        _context.Set<Email>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<EmailTrainer> entities)
    {
        _context.Set<Email>().RemoveRange(entities);
    }

    public void Update(EmailTrainer entity)
    {
        _context.Set<Email>().Update(entity);
    }
}
