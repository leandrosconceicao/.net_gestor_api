using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto.CreateClient, Client>();
            CreateMap<ClientDto.UpdateClient, Client>();
            CreateMap<Client, ClientDto.ReadClient>();
        }
    }
}
