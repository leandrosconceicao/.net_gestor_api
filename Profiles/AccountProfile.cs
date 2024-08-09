using Api.Data.Dtos.AccountDtos;
using Api.Models;
using AutoMapper;

namespace Api.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountDto, Account>();
        CreateMap<Account, AccountDto>();
        CreateMap<UpdateAccountDto, Account>();
    }
}
