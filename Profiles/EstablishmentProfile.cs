using Api.Data.Dtos;
using Api.Models;
using AutoMapper;

namespace Api.Profiles;

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
