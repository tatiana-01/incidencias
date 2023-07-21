using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class TipoHardwareDTO
    {
        public int id {get;set;}
        public string ? nombreHardware {get;set;}
        public List<HardwaresDTO> hardwares {get; set;}
    }
