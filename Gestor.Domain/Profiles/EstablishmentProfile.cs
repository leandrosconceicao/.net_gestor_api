using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;

namespace Gestor.Domain.Profiles;

public class EstablishmentProfile : Profile
{
    public EstablishmentProfile()
    {
        CreateMap<EstablishmentDto.CreateEstablishment, Establishment>();
        CreateMap<EstablishmentDto.UpdateEstablishment, Establishment>();
        CreateMap<Establishment, EstablishmentDto.UpdateEstablishment>();
        CreateMap<Establishment, EstablishmentDto.ReadEstablishment>();
    }
}
