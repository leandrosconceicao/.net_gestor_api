using Gestor.Domain.Entities;

namespace Gestor.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindProductsAsync(int establishmentId, int limit = 50, int offset = 0);

        Task<Product?> FindProductById(int id);

        Task<int> AddProductAsync(Product product);

        Task<bool> DeleteProductAsync(Product product);

        bool UpdateProductAsync(Product product);
    }
}
