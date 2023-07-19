using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Incidencia
    {
        public int id {get; set;}
        public TipoIncidencia tipoIncidencia {get; set;}
        public int idTipoIncidencia {get; set;}
        public Puesto puesto {get; set;}
        public int idPuesto {get; set;}
        public Categoria categoria {get; set;}
        public int idCategoria {get; set;}
        public Trainer trainer {get; set;}
        public string ? idTrainer {get; set;}
        public string ? descripcion {get; set;}
        public DateTime fechaReporte {get;set;}
    }
