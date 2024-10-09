
using Gestor.Domain.Entities;

namespace Gestor.Repository.Implementations
{
    public interface IEstablishmentRepository
    {
        Task<IEnumerable<Establishment>> FindEstablishmentAsync(int offset = 0, int limit = 50);

        Task<Establishment?> FindEstablishmentById(int id);

        Task<int> AddEstablishmentAsync(Establishment establishment);

        Task<bool> DeleteEstablishmentAsync(int id);

        Task<bool> UpdateEstablishmentAsync(int id, Establishment establishment);
    }
}
