using Gestor.Domain.Entities;
using Gestor.Helpers.Models.EstablishmentDtos;
using Gestor.Helpers.Models.UserDtos;

namespace Gestor.Helpers.Models.AccountDtos
{

    public class AccountDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public AccountStatus Status { get; set; } = AccountStatus.Open;

        public int UserId { get; set; }

        public virtual ReadUserDto User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int EstablishmentId { get; set; }

        public virtual ReadEstablishmentDto Establishment { get; set; }
        public Client? Client { get; set; } = new Client();
    }
}