using Dapper;
using Gestor.Domain.Entities;
using Gestor.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Gestor.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApiContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AccountRepository(ApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public void Add(Account entity)
        {
            _context.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            string query = "UPDATE accounts SET Deleted = @Id WHERE Id = @Id";
            using var con = new MySqlConnection(_connectionString);
            int affectedRows = await con.ExecuteAsync(query, new {Id = id});
            return affectedRows > 0;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(Account entity)
        {
            _context.Update(entity);
        }

        public async Task<Account?> FindById(int id)
        {
            string query = @"SELECT 
                acc.Id,
                acc.Description,
                acc.Status,
                acc.UserId,
                acc.CreatedAt,
                acc.UpdatedAt,
                acc.EstablishmentId,
                acc.ClientId,
                usr.Id,
                usr.Email,
                usr.Password,
                usr.UserName,
                usr.IsActived,
                usr.ChangePassword,
                usr.IsDeleted,
                usr.Token,
                usr.CreatedAt,
                usr.UpdateAt,
                usr.EstablishmentId,
                usr.Role,
                cli.Id,
                cli.Cgc,
                cli.Name,
                cli.Email,
                cli.PhoneNumber,
                cli.CreatedAt,
                cli.UpdatedAt, 
                est.Id,
                est.Description,
                est.OwnerId,
                est.LogoFilePath,
                est.IsOpen,
                est.Address,
                est.Url,
                est.PixKey,
                est.Instagram,
                est.Whatsapp,
                est.Email,
                est.Phone,
                est.Deleted,
                est.CreatedAt,
                est.UpdatedAt                   
            FROM
                accounts AS acc
                    INNER JOIN
                users AS usr ON acc.UserId = usr.Id
                    INNER JOIN
                clients AS cli ON acc.ClientId = cli.Id
                    INNER JOIN
                establishments AS est ON acc.EstablishmentId = est.Id
                    INNER JOIN
                clientaddresses AS cliadd ON cliadd.ClientId = cli.Id
		            where acc.Id = @Id
                ORDER BY acc.Id, usr.Id, cli.Id, est.Id";
            using var con = new MySqlConnection(_connectionString);
            var accounts = await con.QueryAsync<Account, User, Client, Establishment, Account>(query, (account, user, client, establishment) =>
            {
                account.User = user;
                account.Establishment = establishment;
                account.User.Establishment = establishment;
                account.Client = client;
                return account;
            }, new { Id = id });
            return accounts.FirstOrDefault();
        }

        public async Task<IEnumerable<Account>> FindAll(int establishmentId, int offset = 0, int limit = 50)
        {
            string query = @"SELECT 
                                acc.Id,
                                acc.Description,
                                acc.Status,
                                acc.UserId,
                                acc.CreatedAt,
                                acc.UpdatedAt,
                                acc.EstablishmentId,
                                acc.ClientId
                            FROM
                                accounts AS acc
                            WHERE
                                acc.Deleted IS NULL
                                    AND acc.EstablishmentId = @EstablishmentId
                            LIMIT @Limit OFFSET @Offset";
            using var con = new MySqlConnection(_connectionString);
            var accounts = await con.QueryAsync<Account>(query, new { EstablishmentId = establishmentId, Limit = limit, Offset = offset });
            return accounts;
        }
    }
}
