using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class TipoHardware
    {
        public int id {get;set;}
        public string ? nombreHardware {get;set;}
        public ICollection<Hardware> hardwares {get; set;}
    }
