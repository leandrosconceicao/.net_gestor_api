using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.UserDtos;

namespace Gestor.Helpers.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, ReadUserDto>();
    }
}
