using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Interfaces
{
    public interface IUserHandler
    {
        User Create(UserDto.CreateUser dto);
        User Update(UserDto.Update dto, User User);
        IApiResponse Read(User account);
        IApiResponse Read(IEnumerable<User> accounts);
    }
}
