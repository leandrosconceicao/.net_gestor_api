using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Interfaces
{
    public interface IAccountHandler
    {
        Account Create(AccountDto.Create dto);

        AccountDto.Read Read(Account account);

        List<AccountDto.Read> Read(IEnumerable<Account> accounts);
    }
}
