using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Area
    {
        public int id {get;set;}
        public string ? nombreArea {get;set;}
        public string ? descripcion {get;set;}
        public ICollection<Salon> salones {get; set;}
    }
