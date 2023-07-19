using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class TelefonoTrainer
    {
        public Trainer trainer {get; set;}
        public string ? idTrainer {get; set;}
        public Telefono telefono {get; set;}
        public int idTelefono {get; set;}
        public string ? numeroTelefono {get; set;}
    }
