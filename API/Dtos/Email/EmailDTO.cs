using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class EmailDTO
    {
        public int id {get; set;}
        public string ? tipoEmail {get;set;}
        public string ? descripcion {get;set;}
        public List<EmailTrainersDTO> emailsTrainers {get;set;}

    }
