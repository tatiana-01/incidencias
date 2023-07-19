using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;

    public interface IUnitOfWork
    {
        IArea Areas {get; set;}
        ICategoria Categorias {get; set;}
        IEmail Emails {get; set;}
        IEmailTrainer EmailsTrainers {get; set;}
        IHardware Hardwares {get; set;}
        IIncidencia Incidencias {get; set;}
        IPuesto Puestos {get; set;}
        ISalon Salones {get; set;}
        ISoftware Softwares {get; set;}
        ITelefono Telefonos {get; set;}
        ITelefonoTrainer TelefonosTrainers {get; set;}
        ITipoHardware TiposHardwares {get;set;}
        ItipoIncidencia TiposIncidencias {get; set;}
        ITipoSoftware TiposSoftwares {get; set;}
        ITrainer Trainers {get; set;}
        Task<int> saveAsync();
    }
