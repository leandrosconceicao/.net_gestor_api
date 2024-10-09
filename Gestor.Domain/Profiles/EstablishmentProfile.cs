using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.EstablishmentDtos;

namespace Gestor.Domain.Profiles;

public class EstablishmentProfile : Profile
{
    public EstablishmentProfile()
    {
        CreateMap<CreateEstablishmentDto, Establishment>();
        CreateMap<UpdateEstablishmentDto, Establishment>();
        CreateMap<Establishment, UpdateEstablishmentDto>();
        CreateMap<Establishment, ReadEstablishmentDto>();
    }
}
