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
            CreateMap<Categoria,CategoriasDTO>().ReverseMap();
            CreateMap<Categoria,CategoriaPostDTO>().ReverseMap();
            
            CreateMap<Email,EmailDTO>().ReverseMap();
            CreateMap<Email,EmailsDTO>().ReverseMap();
            CreateMap<Email,EmailPostDTO>().ReverseMap();

            CreateMap<EmailTrainer,EmailTrainersDTO>().ReverseMap();

            CreateMap<Hardware,HardwaresDTO>().ReverseMap();
            CreateMap<Hardware,HardwarePostDTO>().ReverseMap();

            CreateMap<Incidencia,IncidenciasDTO>().ReverseMap();
            CreateMap<Incidencia,IncidenciaPostDTO>().ReverseMap();

            CreateMap<Software,SoftwaresDTO>().ReverseMap();
            CreateMap<Software,SoftwarePostDTO>().ReverseMap();

            CreateMap<Telefono,TelefonoDTO>().ReverseMap();
            CreateMap<Telefono,TelefonosDTO>().ReverseMap();
            CreateMap<Telefono,TelefonoPostDTO>().ReverseMap();

            CreateMap<TelefonoTrainer,TelefonoTrainersDTO>().ReverseMap();

            CreateMap<TipoHardware,TipoHardwareDTO>().ReverseMap();
            CreateMap<TipoHardware,TipoHardwaresDTO>().ReverseMap();
            CreateMap<TipoHardware,TipoHardwarePostDTO>().ReverseMap();

            CreateMap<TipoIncidencia,TipoIncidenciaDTO>().ReverseMap();
            CreateMap<TipoIncidencia,TipoIncidenciasDTO>().ReverseMap();
            CreateMap<TipoIncidencia,TipoIncidenciaPostDTO>().ReverseMap();

            CreateMap<TipoSoftware,TipoSoftwareDTO>().ReverseMap();
            CreateMap<TipoSoftware,TipoSoftwaresDTO>().ReverseMap();
            CreateMap<TipoSoftware,TipoSoftwarePostDTO>().ReverseMap();

            CreateMap<Trainer,TrainerDTO>().ReverseMap();
            CreateMap<Trainer,TrainersDTO>().ReverseMap();
            CreateMap<Trainer,TrainerPostDTO>().ReverseMap();
        }
        
    }
