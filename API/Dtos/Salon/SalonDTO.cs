using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class SalonDTO
    {
        public int id {get;set;}
        public int idArea {get; set;}
        public string ? nombreSalon {get; set;}
        public string ? numeroPuestos {get; set;}
        public List<PuestosDTO> puestos {get; set;}
    }
