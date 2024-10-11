using Dapper;
using Gestor.Domain.Entities;
using Gestor.Repository.Db;
using Gestor.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Gestor.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly IConfiguration _configuration;
        private readonly ApiContext _context;
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration, ApiContext context)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlConnection");
            _context = context;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Product?> FindProductById(int id)
        {
            return _context.Products
                .Include(prod => prod.Category)
                .Include(prod => prod.ProductExtras)
                .ThenInclude(extras => extras.ProductExtra)
                .ThenInclude(extraItem => extraItem.Items)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> FindProductsAsync(int establishmentId, int limit = 50, int offset = 0)
        {
            string query = @"SELECT 
	                            *
		                    FROM products
                                WHERE Deleted IS NULL AND EstablishmentId = @Id
                            LIMIT @Limit OFFSET @Offset";
            using var con = new MySqlConnection(_connectionString);
            var products = await con.QueryAsync<Product>(query, new { Id = establishmentId, Limit = limit, Offset = offset });
            return products;
        }

        public bool UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            var rows = _context.SaveChangesAsync();
            rows.Wait();
            return rows.Result > 0;
        }
    }
}
