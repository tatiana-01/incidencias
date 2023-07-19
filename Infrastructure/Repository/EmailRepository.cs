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

    public class EmailRepository : IEmail
    {
    private readonly IncidenciasContext _context;

    public EmailRepository(IncidenciasContext context){
        _context = context;
    }
    public void Add(Email entity)
    {
        _context.Set<Email>().Add(entity);
    }

    public void AddRange(IEnumerable<Email> entities)
    {
        _context.Set<Email>().AddRange(entities);
    }

    public IEnumerable<Email> Find(Expression<Func<Email, bool>> expression)
    {
        return _context.Set<Email>().Where(expression);
    }

    public async Task<IEnumerable<Email>>? GetAllAsync()
    {
        return await _context.Set<Email>().ToListAsync();
    }

    public async Task<Email>? GetByIdAsync(int id)
    {
        return await _context.Emails
        .Include(p=>p.emailsTrainers)
        .FirstOrDefaultAsync(p=>p.id == id);
    }

    public void Remove(Email entity)
    {
        _context.Set<Email>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Email> entities)
    {
        _context.Set<Email>().RemoveRange(entities);
    }

    public void Update(Email entity)
    {
        _context.Set<Email>().Update(entity);
    }
    }
