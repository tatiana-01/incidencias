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
    private HardwareRepository _hardwares;
    private IncidenciaRepository _incidencias;
    private PuestoRepository _puestos;
    private SalonRepository _salones;    
    private SoftwareRepository _softwares; 
    private TelefonoRepository _telefonos;
    private TelefonoTrainerRepository _telefonosTrainers;
    private TipoHardwareRepository _tiposHardwares;
    private TipoIncidenciaRepository _tiposIncidencias;
    private TipoSoftwareRepository _tiposSoftwares;
    private TrainerRepository _trainers;

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
    public IEmail Emails {
        get{
            if(_emails == null){
                _emails = new EmailRepository(context);
            }
            return _emails;
        }
    }
    public IEmailTrainer EmailsTrainers {
        get{
            if(_emailsTrainers == null){
                _emailsTrainers = new EmailTrainerRepository(context);
            }
            return _emailsTrainers;
        }
    }
    public IHardware Hardwares {
        get{
            if(_hardwares == null){
                _hardwares = new HardwareRepository(context);
            }
            return _hardwares;
        }
    }
    public IIncidencia Incidencias {
        get{
            if(_incidencias == null){
                _incidencias = new IncidenciaRepository(context);
            }
            return _incidencias;
        }
    }
    public IPuesto Puestos {
        get{
            if(_puestos == null){
                _puestos = new PuestoRepository(context);
            }
            return _puestos;
        }
    }
    public ISalon Salones {
        get{
            if(_salones == null){
                _salones = new SalonRepository(context);
            }
            return _salones;
        }
    }
    public ISoftware Softwares {
        get{
            if(_softwares == null){
                _softwares = new SoftwareRepository(context);
            }
            return _softwares;
        }
    }
    public ITelefono Telefonos {
        get{
            if(_telefonos == null){
                _telefonos = new TelefonoRepository(context);
            }
            return _telefonos;
        }
    }
    public ITelefonoTrainer TelefonosTrainers {
        get{
            if(_telefonosTrainers == null){
                _telefonosTrainers = new TelefonoTrainerRepository(context);
            }
            return _telefonosTrainers;
        }
    }
    public ITipoHardware TiposHardwares {
        get{
            if(_tiposHardwares == null){
                _tiposHardwares = new TipoHardwareRepository(context);
            }
            return _tiposHardwares;
        }
    }
    public ItipoIncidencia TiposIncidencias {
        get{
            if(_tiposIncidencias == null){
                _tiposIncidencias = new TipoIncidenciaRepository(context);
            }
            return _tiposIncidencias;
        }
    }
    public ITipoSoftware TiposSoftwares {
        get{
            if(_tiposSoftwares == null){
                _tiposSoftwares = new TipoSoftwareRepository(context);
            }
            return _tiposSoftwares;
        }
    }
    public ITrainer Trainers {
        get{
            if(_trainers == null){
                _trainers = new TrainerRepository(context);
            }
            return _trainers;
        }
    }


    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return context.SaveChangesAsync();
    }
}
