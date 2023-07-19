using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class TipoSoftware
    {
        public int id {get; set;}
        public string ? nombreSoftware {get; set;}
        public ICollection<Software> softwares {get;set;}
    }
