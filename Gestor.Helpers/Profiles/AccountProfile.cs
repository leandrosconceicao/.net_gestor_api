using Gestor.Helpers.Models.AccountDtos;
using AutoMapper;
using Gestor.Domain.Entities;

namespace Gestor.Helpers.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountDto, Account>();
        CreateMap<Account, ReadAccountDto>();
        CreateMap<UpdateAccountDto, Account>();
    }
}
