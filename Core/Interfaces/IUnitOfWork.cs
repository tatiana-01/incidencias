using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;

    public interface IUnitOfWork
    {
        IArea Areas {get; }
        ICategoria Categorias {get; }
        IEmail Emails {get; }
        IEmailTrainer EmailsTrainers {get; }
        IHardware Hardwares {get; }
        IIncidencia Incidencias {get; }
        IPuesto Puestos {get; }
        ISalon Salones {get; }
        ISoftware Softwares {get; }
        ITelefono Telefonos {get; }
        ITelefonoTrainer TelefonosTrainers {get; }
        ITipoHardware TiposHardwares {get;}
        ItipoIncidencia TiposIncidencias {get; }
        ITipoSoftware TiposSoftwares {get; }
        ITrainer Trainers {get; }
        Task<int> SaveAsync();
    }
