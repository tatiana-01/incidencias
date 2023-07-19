using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IncidenciasContext context;
    private AreaRepository _areas;
    private CategoriaRepository _categorias;
    private EmailRepository _emails;
    private EmailTrainerRepository _emailsTrainers;
    

    public UnitOfWork(IncidenciasContext _context){
        context=_context;
    }
    public IArea Areas {
        get{
            if(_areas == null){
                _areas = new AreaRepository(context);
            }
            return _areas;
        }
    }

    public ICategoria Categorias { 
        get{
            if(_categorias == null){
                _categorias = new CategoriaRepository(context);
            }
            return _categorias;
        }
    }
    public IEmail Emails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IEmailTrainer EmailsTrainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> saveAsync()
    {
        return context.SaveChangesAsync();
    }
}
