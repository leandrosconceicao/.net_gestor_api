using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;
using Gestor.Domain.Interfaces;

namespace Gestor.Domain.Handlers
{
    public class AccountHandler(IMapper mapper) : IAccountHandler
    {
        public Account Create(AccountDto.Create dto)
        {
            return mapper.Map<Account>(dto);
        }

        public AccountDto.Read Read(Account account)
        {
            return mapper.Map<AccountDto.Read>(account);
        }

        public List<AccountDto.Read> Read(IEnumerable<Account> accounts)
        {
            return mapper.Map<List<AccountDto.Read>>(accounts);
        }
    }
}
