using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos;

    public class AreaDTO
    {
        public int id {get;set;}
        public string ? nombreArea {get;set;}
        public string ? descripcion {get;set;}
        public List<SalonesDTO> salones {get;set;}
    }
    
