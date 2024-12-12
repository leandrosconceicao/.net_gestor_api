using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Interfaces
{
    public interface IAccountHandler
    {
        Entities.Account Create(Dtos.AccountDto.CreateAccount dto);

        IApiResponse Read(Entities.Account account);

        IApiResponse Read(IEnumerable<Entities.Account> accounts);
    }
}
