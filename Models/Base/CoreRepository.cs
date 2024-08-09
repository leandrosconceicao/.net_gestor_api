
using Api.Data;
using Api.Data.Dtos.AccountDtos;
using Api.Data.Dtos.EstablishmentDtos;
using Api.Data.Dtos.UserDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Base
{
    public class CoreRepository : ICoreRepository
    {
        private readonly ApiContext _context;

        public CoreRepository(ApiContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<User?> FindUserById(int id)
        {
            User? query = await _context.Users
                .Include(user => user.Establishment)
                .FirstOrDefaultAsync(user => user.Id == id);
            return query;
        }

        public async Task<IEnumerable<User>> FindAllUsers(int offset, int limit)
        {
            IEnumerable<User> query = await _context.Users
                .Skip(offset)
                .Take(limit)
                // .Include(user => user.Establishment)
                .ToListAsync();
            return query;
        }

        public async Task<Establishment?> FindEstablishmentById(int id)
        {
            Establishment? query = await _context.Establishments
                .FirstOrDefaultAsync(est => est.Id == id);
            return query;
        }

        public async Task<IEnumerable<Establishment>> FindAllEstablishments(int offset = 0, int limit = 50)
        {
            List<Establishment> query = await _context.Establishments
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
            return query;
        }

        public async Task<Account?> FindAccountById(int id)
        {
            var query = await _context.Accounts
                .Include(acc => acc.Client)
                .Include(acc => acc.Client.Addresses)
                .Include(acc => acc.Establishment)
                .Include(acc => acc.User)
                .FirstOrDefaultAsync(acc => acc.Id == id);
            return query;
        }

        public async Task<IEnumerable<Account>> FindAllAccounts(int establishmentId, int offset = 0, int limit = 50)
        {
            var query = await _context.Accounts
                .Skip(offset)
                .Take(limit)
                .Where(account => account.EstablishmentId == establishmentId)
                .ToListAsync();
            return query;
        }
    }
}
