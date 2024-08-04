
using Api.Data;
using Api.Data.Dtos.EstablishmentDtos;
using Api.Data.Dtos.UserDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Base
{
    public class CoreRepository : ICoreRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CoreRepository(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<ReadUserDto?> FindUserById(int id)
        {
            User? query = await _context.Users
                .Include(user => user.Establishment)
                .FirstOrDefaultAsync(user => user.Id == id);
            return query == null ? null : _mapper.Map<ReadUserDto>(query);
        }

        public async Task<IEnumerable<ReadUserDto>> FindAllUsers(int offset, int limit)
        {
            IEnumerable<User> query = await _context.Users
                .Skip(offset)
                .Take(limit)
                .Include(user => user.Establishment)
                .ToListAsync();
            return _mapper.Map<List<ReadUserDto>>(query);
        }

        public async Task<ReadEstablishmentDto?> FindEstablishmentById(int id)
        {
            Establishment? query = await _context.Establishments
                .FirstOrDefaultAsync(est => est.Id == id);
            return query == null ? null : _mapper.Map<ReadEstablishmentDto>(query);
        }

        public async Task<IEnumerable<ReadEstablishmentDto>> FindAllEstablishments(int offset = 0, int limit = 50)
        {
            List<Establishment> query = await _context.Establishments.ToListAsync();
            return _mapper.Map<IEnumerable<ReadEstablishmentDto>>(query);
        }
    }
}
