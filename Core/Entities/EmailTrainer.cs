using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class EmailTrainer
    {
        public Trainer trainer {get; set;}
        public string ? idTrainer {get;set;}
        public Email email {get; set;}
        public int idEmail {get;set;}
        public string ? trainerEmail {get;set;}
    }
