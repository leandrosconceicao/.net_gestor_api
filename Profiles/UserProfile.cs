using Api.Data.Dtos.UserDtos;
using Api.Models;
using AutoMapper;

namespace Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, ReadUserDto>();
    }
}
