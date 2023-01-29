using AutoMapper;
using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cuenta, CuentaCreacionVM>();
            CreateMap<TransaccionActualizacionVM, Transaccion>().ReverseMap();
        }
    }
}
