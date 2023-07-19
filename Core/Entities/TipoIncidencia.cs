using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class TipoIncidencia
    {
        public int id {get; set;}
        public string ? NivelIncidencia {get; set;}
        public ICollection<Incidencia> incidencias {get; set;}
    }
