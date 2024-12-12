using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Interfaces
{
    public interface IEstablishmentHandler
    {
        Establishment Create(EstablishmentDto.CreateEstablishment dto);
        Establishment Update(EstablishmentDto.UpdateEstablishment dto, Establishment establishment);

        EstablishmentDto.ReadEstablishment Read(Establishment account);

        List<EstablishmentDto.ReadEstablishment> Read(IEnumerable<Establishment> accounts);
    }
}
