using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Interfaces
{
    public interface IEstablishmentHandler
    {
        Establishment Create(EstablishmentDto.Create dto);
        Establishment Update(EstablishmentDto.Update dto, Establishment establishment);

        EstablishmentDto.Read Read(Establishment account);

        List<EstablishmentDto.Read> Read(IEnumerable<Establishment> accounts);
    }
}
