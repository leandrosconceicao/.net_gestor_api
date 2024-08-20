using Dapper;
using Gestor.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Gestor.Repository.Implementations
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public EstablishmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public async Task<IEnumerable<Establishment>> FindEstablishmentAsync(int offset = 0, int limit = 50)
        {
            string query = @"SELECT * FROM establishments
                                WHERE Deleted IS NULL
                                    LIMIT @Limit OFFSET @Offset";
            using var con = new MySqlConnection(_connectionString);
            var establishments = await con.QueryAsync<Establishment>(query, new {Offset = offset, Limit = limit});
            return establishments;
        }

        public async Task<Establishment?> FindEstablishmentById(int id)
        {
            string query = @"SELECT * 
                                FROM establishments 
                                    WHERE Id = @Id ";
            using var con = new MySqlConnection(_connectionString);
            var establishment = await con.QueryFirstOrDefaultAsync<Establishment>(query, new {Id = id});
            return establishment;
        }
        public async Task<int> AddEstablishmentAsync(Establishment establishment)
        {
            string query = @"insert into establishments(
	                            Description, 
                                OwnerId, 
                                LogoFilePath, 
                                IsOpen, 
                                Address, 
                                Url,
                                PixKey,
                                Email,
                                Instagram,
                                Phone,
                                Whatsapp
                            ) values (
                                @Description, 
                                @OwnerId, 
                                @LogoFilePath, 
                                @IsOpen, 
                                @Address, 
                                @Url, 
                                @PixKey,
                                @Email, 
                                @Instagram,
                                @Phone, 
                                @Whatsapp
                            );
                            SELECT LAST_INSERT_ID();";
            using var con = new MySqlConnection(_connectionString);
            var insertId = await con.ExecuteScalarAsync<int>(query, establishment);
            return insertId;
        }

        public async Task<bool> DeleteEstablishmentAsync(int id)
        {
            string query = @"UPDATE establishments SET Deleted = @Id
                                WHERE Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            var rowsAffected = await con.ExecuteAsync(query, new {Id = id});
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateEstablishmentAsync(int id, Establishment establishment)
        {
            string query = @"UPDATE establishments SET 
                                Description = @Description,
                                OwnerId = @OwnerId,
                                LogoFilePath = @LogoFilePath,
                                IsOpen = @IsOpen,
                                Address = @Address,
                                Url = @Url,
                                PixKey = @PixKey,
                                Instagram = @Instagram,
                                Whatsapp = @Whatsapp,
                                Email = @Email,
                                Phone = @Phone,
                            WHERE 
                                Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            int rowsAffected = await con.ExecuteAsync(query, new { 
                Id = id, 
                establishment.Description, 
                establishment.OwnerId, 
                establishment.LogoFilePath,
                establishment.IsOpen,
                establishment.Address,
                establishment.Url,
                establishment.PixKey,
                establishment.Instagram,
                establishment.Whatsapp,
                establishment.Email,
                establishment.Phone,
            });
            return rowsAffected > 0;
        }
    }
}
