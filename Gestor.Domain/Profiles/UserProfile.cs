using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;

namespace Gestor.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto.CreateUser, User>();
        CreateMap<UserDto.Update, User>();
        CreateMap<User, UserDto.ReadUser>();
    }
}
