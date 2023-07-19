using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Salon
    {
        public int id {get;set;}
        public Area area {get;set;}
        public int idArea {get; set;}
        public string ? nombreSalon {get; set;}
        public string ? numeroPuestos {get; set;}
        public ICollection<Puesto> puestos {get;set;}
    }
