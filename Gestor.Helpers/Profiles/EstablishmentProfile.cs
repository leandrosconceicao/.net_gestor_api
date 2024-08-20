using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.EstablishmentDtos;

namespace Gestor.Helpers.Profiles;

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
