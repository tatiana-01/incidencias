using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Puesto
    {
        public int id {get;set;}
        public string ? nombrePuesto {get;set;}
        public Salon salon {get;set;}
        public int idSalon {get;set;}
        public ICollection<Hardware> hardwares {get;set;}
        public ICollection<Incidencia> incidencias {get;set;}
        public ICollection<Software> ? softwares {get;set;}
    }
