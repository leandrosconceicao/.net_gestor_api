using Gestor.Domain.Dtos.AccountDtos;
using AutoMapper;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountDto, Account>();
        CreateMap<Account, ReadAccountDto>();
        CreateMap<UpdateAccountDto, Account>();
    }
}
