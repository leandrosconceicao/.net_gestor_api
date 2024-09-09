using Dapper;
using Gestor.Domain.Entities;
using Gestor.Repository.Interfaces;
using Google.Protobuf.Collections;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Gestor.Repository.Implementations
{
    public class ProductExtraRepository : IProductExtraRepository
    {
        private readonly ApiContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProductExtraRepository(IConfiguration configuration, ApiContext context)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
            _context = context;
        }

        public async Task<int> AddProductExtraAsync(ProductExtra extra)
        {
            _context.ProductExtras.Add(extra);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductExtra?> FindProductExtraById(int id)
        {
            string query = @"SELECT * FROM 
                                productextras px
                                    LEFT JOIN
                                        productextraitems prodex ON prodex.ProductExtraId = px.Id
                                    WHERE px.Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            var productExtra = await con.QueryAsync<ProductExtra, ProductExtraItem, ProductExtra>(query, (productExtra, ProductExtraItem) => {
                productExtra.Items.Add(ProductExtraItem);
                return productExtra;
            }, new { Id = id });
            var groupExtras = productExtra.GroupBy(extra => extra.Id).Select(e =>
            {
                var groupedExtra = e.First();
                groupedExtra.Items = e.Select(p => p.Items.Single()).ToList();
                return groupedExtra;
            }).ToList();
            return groupExtras.FirstOrDefault();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            string query = @"UPDATE productextras 
                                SET Deleted = @Id
                                    WHERE Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            int rowsAffectd = await con.ExecuteAsync(query, new { Id = id });
            return rowsAffectd > 0;
        }

        public async Task<IEnumerable<ProductExtra>> FindProductExtrasAsync(int establishmentId, int limit = 50, int offset = 0)
        {
            string query = @"SELECT 
                                *
                            FROM
                                productextras
                            WHERE
                                Deleted is NULL AND EstablishmentId = @EstablishmentId";
            using var con = new MySqlConnection(_connectionString);
            var productExtras = await con.QueryAsync<ProductExtra>(query, new
            {
                EstablishmentId = establishmentId
            });
            return productExtras;
        }
    }
}
