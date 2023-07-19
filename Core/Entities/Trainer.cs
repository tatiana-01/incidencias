using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Trainer
    {
        public string ? id {get; set;}
        public string ? nombreCompleto {get; set;}
        public ICollection<TelefonoTrainer> telefonosTrainers {get; set;}
        public ICollection<EmailTrainer> emailsTrainers {get; set;}
        public ICollection<Incidencia> incidencias {get; set;}

    }
