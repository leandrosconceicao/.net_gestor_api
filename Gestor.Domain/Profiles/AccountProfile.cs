using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDto.CreateAccount, Account>();
            CreateMap<Account, AccountDto.ReadAccount>();
            CreateMap<AccountDto.UpdateAccount, Account>();
        }
    }
}
