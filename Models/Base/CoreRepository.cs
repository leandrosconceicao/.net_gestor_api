
using Api.Data;
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
            return await _context.Users
                .Include(user => user.Establishment)
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> FindAllUsers(int offset, int limit) { 
            return await _context.Users   
                .Skip(offset)
                .Take(limit)
                .Include(user => user.Establishment)
                .ToListAsync();
        }

        public async Task<Establishment?> FindEstablishmentById(int id)
        {
            return await _context.Establishments.FindAsync(id);
        }

        public async Task<IEnumerable<Establishment>> FindAllEstablishments(int offset = 0, int limit = 50)
        {
            return await _context.Establishments.ToListAsync();
        }
    }
}
