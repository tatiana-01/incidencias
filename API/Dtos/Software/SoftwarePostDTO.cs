using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class SoftwarePostDTO
    {
        public string ? descripcion {get; set;}
        public int idTipoSoftware {get; set;}
        public int idPuesto {get; set;}
        public int idCategoria {get; set;}
    }
