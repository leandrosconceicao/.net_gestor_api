using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.UserDtos;

namespace Gestor.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, ReadUserDto>();
    }
}
