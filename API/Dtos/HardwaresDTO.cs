using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class HardwaresDTO
    {
        public int id {get;set;}
        public int idTipoHardware {get;set;}
        public int idPuesto {get;set;}
        public int idCategoria {get;set;}
        public string ? descripcion {get;set;}
    }
