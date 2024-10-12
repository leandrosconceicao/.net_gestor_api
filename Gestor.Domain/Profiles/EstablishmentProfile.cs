using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;

namespace Gestor.Domain.Profiles;

public class EstablishmentProfile : Profile
{
    public EstablishmentProfile()
    {
        CreateMap<EstablishmentDto.Create, Establishment>();
        CreateMap<EstablishmentDto.Update, Establishment>();
        CreateMap<Establishment, EstablishmentDto.Update>();
        CreateMap<Establishment, EstablishmentDto.Read>();
    }
}
