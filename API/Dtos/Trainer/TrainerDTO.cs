using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class TrainerDTO
    {
        public string ? id {get; set;}
        public string ? nombreCompleto {get; set;}
        public List<TelefonoTrainersDTO> telefonosTrainers {get; set;}
        public List<EmailTrainersDTO> emailsTrainers {get; set;}
        public List<IncidenciasDTO> incidencias {get; set;}
    }
