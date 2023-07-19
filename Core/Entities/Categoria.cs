using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Categoria
    {
        public int id {get; set;}
        public string ? nombreCategoria {get; set;}
        public ICollection<Incidencia> incidencias {get; set;}
        public ICollection<Hardware> hardwares {get; set;}
        public ICollection<Software> softwares {get; set;}
    }