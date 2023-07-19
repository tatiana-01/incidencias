using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Email
    {
        public int id {get; set;}
        public string ? tipoEmail {get;set;}
        public string ? descripcion {get;set;}
        public ICollection<EmailTrainer> emailsTrainers {get;set;}
    }
