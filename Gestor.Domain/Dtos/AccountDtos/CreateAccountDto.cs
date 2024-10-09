using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.ClientDtos;

namespace Gestor.Domain.Dtos.AccountDtos
{
    public class CreateAccountDto
    {
        public string Description { get; set; }

        public AccountStatus Status { get; set; } = AccountStatus.Open;

        public int UserId { get; set; }

        public int EstablishmentId { get; set; }

        public CreateClientDto? Client { get; set; } = new CreateClientDto();
    }
}
