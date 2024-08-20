using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.ClientDtos;

namespace Gestor.Helpers.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, Client>();
        }
    }
}
