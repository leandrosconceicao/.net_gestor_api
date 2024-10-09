using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.ClientDtos;

namespace Gestor.Domain.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, Client>();
        }
    }
}
