using Gestor.Helpers.Models.AccountDtos;
using AutoMapper;
using Gestor.Domain.Entities;

namespace Gestor.Helpers.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountDto, Account>();
        CreateMap<Account, AccountDto>();
        CreateMap<UpdateAccountDto, Account>();
    }
}
