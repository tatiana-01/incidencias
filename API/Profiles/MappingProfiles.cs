using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;

    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Area,AreaDTO>().ReverseMap();
            CreateMap<Area,AreasDTO>().ReverseMap();
            CreateMap<Area,AreaPostDTO>().ReverseMap();

            CreateMap<Salon,SalonDTO>().ReverseMap();
            CreateMap<Salon,SalonesDTO>().ReverseMap();
            CreateMap<Salon,SalonPostDTO>().ReverseMap();

            CreateMap<Puesto,PuestoDTO>().ReverseMap();
            CreateMap<Puesto,PuestosDTO>().ReverseMap();
            CreateMap<Puesto,PuestoPostDTO>().ReverseMap();

            CreateMap<Categoria,CategoriaDTO>().ReverseMap();
            CreateMap<Email,EmailDTO>().ReverseMap();
            CreateMap<EmailTrainer,EmailTrainerDTO>().ReverseMap();
            CreateMap<Hardware,HardwaresDTO>().ReverseMap();
            CreateMap<Incidencia,IncidenciasDTO>().ReverseMap();
            CreateMap<Software,SoftwaresDTO>().ReverseMap();
            CreateMap<Telefono,TelefonoDTO>().ReverseMap();
            CreateMap<TelefonoTrainer,TelefonoTrainerDTO>().ReverseMap();
            CreateMap<TipoHardware,TipoHardwareDTO>().ReverseMap();
            CreateMap<TipoIncidencia,TipoIncidenciaDTO>().ReverseMap();
            CreateMap<TipoSoftware,TipoSoftwareDTO>().ReverseMap();
            CreateMap<Trainer,TrainerDTO>().ReverseMap();
        }
        
    }
