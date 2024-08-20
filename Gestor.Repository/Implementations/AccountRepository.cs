using Gestor.Domain.Entities;
using Gestor.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApiContext _context;

        public AccountRepository(ApiContext context)
        {
            _context = context;

        }

        public void Add(Account entity)
        {
            _context.Add(entity);
        }

        public void Delete(Account entity)
        {
            _context.Remove(entity);
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
            var query = await _context.Accounts
                .Include(acc => acc.Client)
                .ThenInclude(acc => acc.Addresses)
                .Include(acc => acc.Establishment)
                .Include(acc => acc.User)
                .FirstOrDefaultAsync(acc => acc.Id == id);
            return query;
        }

        public async Task<IEnumerable<Account>> FindAll(int establishmentId, int offset = 0, int limit = 50)
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
