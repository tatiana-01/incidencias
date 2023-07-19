using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Telefono
    {
        public int id {get; set;}
        public string ? tipo {get; set;}
        public  string ? descripcion {get; set;}
        public ICollection<TelefonoTrainer> telefonosTrainers {get;set;}
    }
