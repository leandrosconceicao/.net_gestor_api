using Gestor.Domain.Entities;

namespace Gestor.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        User? AuthUser(string email, string password);
    }
}
