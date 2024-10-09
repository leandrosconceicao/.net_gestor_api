using Dapper;
using Gestor.Domain.Entities;
using Gestor.Repository.Db;
using Gestor.Repository.Interfaces;
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
            return await _context.SaveChangesAsync();
            //string query = @"INSERT INTO products (
            //                 Name,
            //                    IsActive,
            //                    Price,
            //                    RequirePreparation,
            //                    ImagePath,
            //                    CreatedAt,
            //                    EstablishmentId,
            //                    CategoryId
            //                ) VALUES (
            //                 @Name,
            //                    @IsActive,
            //                    @Price,
            //                    @RequirePreparation,
            //                    @ImagePath,
            //                    NOW(),
            //                    @EstablishmentId,
            //                    @CategoryId
            //                );
            //                SELECT LAST_INSERT_ID();
            //                INSERT INTO productxextras (
            //                 Required,
            //                 ProductExtraId,
            //                 ProductId 
            //                ) values (
            //                 @Required,
            //                 @ProductExtraId,
            //                 LAST_INSERT_ID()
            //                )";
            //using var con = new MySqlConnection(_connectionString);
            //int rowsAffectd = await con.ExecuteScalarAsync<int>(query, product);
            //Console.WriteLine(query);
            //return rowsAffectd;
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> FindProductById(int id)
        {
            using var con = new MySqlConnection(_connectionString);
            string query = @"SELECT 
	                            p.Id, 
                                p.Name, 
                                p.IsActive, 
                                p.Price, 
                                p.RequirePreparation, 
                                p.ImagePath,
                                p.CreatedAt,
                                p.UpdatedAt,
                                p.EstablishmentId,
                                p.CategoryId,
                                p.Deleted,
                                pcat.Id,
                                pcat.Description,
                                pcat.ImagePath,
                                pcat.Ordenation,
                                pcat.CreatedAt,
                                pcat.UpdatedAt,
                                pcat.EstablishmentId,
                                px.Id,
                                px.Name,
                                px.MaxQtdAllowed,
                                px.EstablishmentId,
                                px.Deleted,
                                pxi.Id,
                                pxi.Name,
                                pxi.Price
		                    FROM products p
	                            inner join productcategories pcat on pcat.Id = p.CategoryId
                                inner join productextras px on px.Id = pxe.ProductExtraId
                                left join productextraitems pxi on pxi.ProductExtraId = px.Id
	                        where p.Id = @Id
                                group by pxe.Required, pxe.ProductExtraId";
            var products = await con.QueryAsync<Product, ProductCategory, ProductCrossExtras, ProductExtraItem, Product>(query,
                (product, productCategory, productExtra, ProductExtraItem) =>
                    {
                        product.Category = productCategory;
                        product.ProductExtras.Add(productExtra);
                        return product;
                    }, new { Id = id }, splitOn: "EstablishmentId, Id");
            var newProduct = products.First();
            return newProduct;
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
    }
}
