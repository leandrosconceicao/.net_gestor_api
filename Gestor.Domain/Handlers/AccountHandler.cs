using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;
using Gestor.Domain.Interfaces;

namespace Gestor.Domain.Handlers
{
    public class AccountHandler(IMapper mapper) : IAccountHandler
    {
        public Entities.Account Create(Dtos.AccountDto.CreateAccount dto)
        {
            return mapper.Map<Entities.Account>(dto);
        }

        public IApiResponse Read(Entities.Account account)
        {
            return new SuccessResponse<AccountDto.ReadAccount>
            {
                Dados = mapper.Map<Dtos.AccountDto.ReadAccount>(account)
            };
        }

        public IApiResponse Read(IEnumerable<Entities.Account> accounts)
        {
            return new SuccessResponse<List<Dtos.AccountDto.ReadAccount>>
            {
               Dados = mapper.Map<List<Dtos.AccountDto.ReadAccount>>(accounts)
            };
        }
    }
}
