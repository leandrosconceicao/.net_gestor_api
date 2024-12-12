using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;
using Gestor.Domain.Interfaces;

namespace Gestor.Domain.Handlers
{
    public class UserHandler(IMapper mapper) : IUserHandler
    {
        public User Create(UserDto.CreateUser dto)
        {
            return mapper.Map<User>(dto);
        }

        public IApiResponse Read(User user)
        {
            return new SuccessResponse<UserDto.ReadUser> {
                Dados = mapper.Map<UserDto.ReadUser>(user)
            };
        }

        public IApiResponse Read(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        public User Update(UserDto.Update dto, User user)
        {
            return mapper.Map(dto, user);
        }
    }
}
