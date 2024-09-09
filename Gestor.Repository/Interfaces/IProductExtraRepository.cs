using Gestor.Domain.Entities;

namespace Gestor.Repository.Interfaces
{
    public interface IProductExtraRepository
    {
        Task<IEnumerable<ProductExtra>> FindProductExtrasAsync(int establishmentId, int limit = 50, int offset = 0);

        Task<ProductExtra?> FindProductExtraById(int id);

        Task<int> AddProductExtraAsync(ProductExtra extra);

        Task<bool> DeleteProductAsync(int id);
    }
}
