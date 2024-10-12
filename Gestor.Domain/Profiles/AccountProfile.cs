using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDto.Create, Account>();
            CreateMap<Account, AccountDto.Read>();
            CreateMap<AccountDto.Update, Account>();
        }
    }
}
