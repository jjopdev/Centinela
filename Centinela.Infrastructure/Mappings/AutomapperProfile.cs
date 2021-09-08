using AutoMapper;
using Centinela.Core.DTOs;
using Centinela.Core.Entities;

namespace Centinela.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Password, PasswordDTO>();
            CreateMap<PasswordDTO, Password>();
        }
    }
}
