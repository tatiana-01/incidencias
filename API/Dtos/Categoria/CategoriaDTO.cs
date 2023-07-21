using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class CategoriaDTO
    {
        public int id {get; set;}
        public string ? nombreCategoria {get; set;}
        public List<IncidenciasDTO> incidencias {get; set;}
        public List<HardwaresDTO> hardwares {get; set;}
        public List<SoftwaresDTO> softwares {get; set;}
    }
