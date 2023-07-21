using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class IncidenciaPostDTO
    {
        public int idTipoIncidencia {get; set;}
        public int idPuesto {get; set;}
        public int idCategoria {get; set;}
        public string ? idTrainer {get; set;}
        public string ? descripcion {get; set;}
        public DateTime fechaReporte {get;set;}
    }
