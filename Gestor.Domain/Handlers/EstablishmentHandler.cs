using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;
using Gestor.Domain.Interfaces;

namespace Gestor.Domain.Handlers
{
    public class EstablishmentHandler(IMapper mapper) : IEstablishmentHandler
    {
        public Establishment Create(EstablishmentDto.CreateEstablishment dto)
        {
            return mapper.Map<Establishment>(dto);
        }

        public EstablishmentDto.ReadEstablishment Read(Establishment Establishment)
        {
            return mapper.Map<EstablishmentDto.ReadEstablishment>(Establishment);
        }

        public List<EstablishmentDto.ReadEstablishment> Read(IEnumerable<Establishment> Establishments)
        {
            return mapper.Map<List<EstablishmentDto.ReadEstablishment>>(Establishments);
        }

        public Establishment Update(EstablishmentDto.UpdateEstablishment dto, Establishment establishment)
        {
            return mapper.Map(dto, establishment);
        }
    }
}
