using Gestor.Domain.Entities;

namespace Gestor.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindUsersAsync(int establishmentId, int limit = 50, int offset = 0);

        Task<User?> FindUserByIdAsync(int id);

        Task<int> AddUserAsync(User category);

        Task<bool> DeleteUserAsync(int id);
    }
}
