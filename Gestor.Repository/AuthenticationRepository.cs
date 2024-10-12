using Gestor.Domain.Entities;
using Gestor.Domain.Interfaces;
using Gestor.Repository.Db;

namespace Gestor.Repository
{
    public class AuthenticationRepository(ApiContext context) : IAuthenticationRepository
    {
        public User? AuthUser(string email, string password)
        {
            var user = context.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
            return user;
        }
    }
}
