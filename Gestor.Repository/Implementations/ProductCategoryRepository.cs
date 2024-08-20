using Dapper;
using Gestor.Domain.Entities;
using Gestor.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Gestor.Repository.Implementations
{
    public class ProductCategoryRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;

        public ProductCategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public async Task<IEnumerable<ProductCategory>> FindProductCategoriesAsync(int establishmentId, int limit = 50, int offset = 0)
        {
            string query = @"SELECT *
                                FROM productcategories p
                                INNER JOIN establishments est ON p.EstablishmentId = est.Id
                                    WHERE p.EstablishmentId = @EstablishmentId
                                    LIMIT @Limit OFFSET @Offset";

            using var con = new MySqlConnection(_connectionString);
            var productCategories = await con.QueryAsync<ProductCategory, Establishment, ProductCategory>(query, (prodCategory, establishment) =>
            {
                prodCategory.Establishment = establishment;
                return prodCategory;
            }, new { EstablishmentId = establishmentId, Offset = offset, Limit = limit }, splitOn: "EstablishmentId");
            return productCategories;
        }
        public async Task<ProductCategory?> FindProductCategoryById(int id)
        {
            string query = @"SELECT *
                                FROM productcategories p
                                INNER JOIN establishments est ON p.EstablishmentId = est.Id
                                    where p.Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            var productCategories = await con.QueryAsync<ProductCategory, Establishment, ProductCategory>(query, (prodCategory, establishment) => {
                prodCategory.Establishment = establishment;
                return prodCategory;
            },  new { Id = id }, splitOn: "EstablishmentId");
            return productCategories.FirstOrDefault();
        }

        public async Task<bool> AddProductCategoryAsync(ProductCategory category)
        {
            string query = @"INSERT INTO productcategories (Description, ImagePath, Ordenation, EstablishmentId)
                                VALUES (@Description, @ImagePath, @Ordenation, @EstablishmentId)";
            using var con = new MySqlConnection(_connectionString);
            var affectedRows = await con.ExecuteAsync(query, category);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteProductCategoryAsync(int id)
        {
            string query = "delete from productcategories where Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            var deleteProcess = await con.ExecuteAsync(query, new { id });
            return deleteProcess > 0;
        }


    }
}
