using Gestor.Domain.Entities;

namespace Gestor.Repository.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> FindProductCategoriesAsync(int establishmentId, int limit = 50, int offset = 0);

        Task<ProductCategory?> FindProductCategoryById(int id);

        Task<int> AddProductCategoryAsync(ProductCategory category);

        Task<bool> DeleteProductCategoryAsync(int id);
    }
}
