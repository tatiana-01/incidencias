using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Hardware
    {
        public int id {get;set;}
        public TipoHardware tipoHardware{get;set;}
        public int idTipoHardware {get;set;}
        public Puesto puesto {get;set;}
        public int idPuesto {get;set;}
        public Categoria categoria {get; set;}
        public int idCategoria {get;set;}
        public string ? descripcion {get;set;}
    }
