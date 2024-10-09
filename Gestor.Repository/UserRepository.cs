using Dapper;
using Gestor.Domain.Entities;
using Gestor.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Gestor.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public async Task<User?> FindUserByIdAsync(int id)
        {
            string query = @"SELECT *
                                FROM users usr
	                            INNER JOIN establishments est on usr.EstablishmentId = est.Id
		                                WHERE usr.Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            var users = await con.QueryAsync<User, Establishment, User>(query, (user, establishment) =>
            {
                user.Establishment = establishment;
                return user;
            }, new { Id = id });
            return users.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> FindUsersAsync(int establishmentId, int offset = 0, int limit = 0)
        {
            string query = @"SELECT *
                                FROM users
                                    WHERE EstablishmentId = @Id AND Deleted IS NULL
                                LIMIT @Limit OFFSET @Offset";
            using var con = new MySqlConnection(_connectionString);
            var users = await con.QueryAsync<User>(query, new { Id = establishmentId, Limit = limit, Offset = offset });
            return users;
        }
        public async Task<int> AddUserAsync(User user)
        {
            string query = @"INSERT INTO users (
                Email,
                Password,
                UserName,
                IsActived,
                ChangePassword,
                Token,
                EstablishmentId,
                Role,
                CreatedAt
            ) Values (
                @Email,
                @Password,
                @UserName,
                @IsActived,
                @ChangePassword,
                @Token,
                @EstablishmentId,
                @Role,
                STR_TO_DATE(sysdate(), ""%Y-%m-%d %H:%i:%s"")
            );
            SELECT LAST_INSERT_ID();";
            using var con = new MySqlConnection(_connectionString);
            int newUserId = await con.ExecuteScalarAsync<int>(query, user);
            return newUserId;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            string query = @"UPDATE users SET IsDeleted = @Id
                                WHERE Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            int rowsAffectd = await con.ExecuteAsync(query, new { Id = id });
            return rowsAffectd > 0;
        }

    }
}
