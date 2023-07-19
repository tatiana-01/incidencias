using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Software
    {
        public int id {get; set;}
        public string ? descripcion {get; set;}
        public TipoSoftware tipoSoftware {get; set;}
        public int idTipoSoftware {get; set;}
        public Puesto puesto {get; set;}
        public int idPuesto {get; set;}
        public Categoria categoria {get; set;}
        public int idCategoria {get; set;}
    }
