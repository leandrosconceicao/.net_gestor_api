using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;
using Gestor.Domain.Interfaces;

namespace Gestor.Domain.Handlers
{
    public class EstablishmentHandler(IMapper mapper) : IEstablishmentHandler
    {
        public Establishment Create(EstablishmentDto.Create dto)
        {
            return mapper.Map<Establishment>(dto);
        }

        public EstablishmentDto.Read Read(Establishment Establishment)
        {
            return mapper.Map<EstablishmentDto.Read>(Establishment);
        }

        public List<EstablishmentDto.Read> Read(IEnumerable<Establishment> Establishments)
        {
            return mapper.Map<List<EstablishmentDto.Read>>(Establishments);
        }

        public Establishment Update(EstablishmentDto.Update dto, Establishment establishment)
        {
            return mapper.Map(dto, establishment);
        }
    }
}
