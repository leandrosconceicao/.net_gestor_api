using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.EstablishmentDtos;
using Gestor.Domain.Dtos.UserDtos;

namespace Gestor.Domain.Dtos.AccountDtos
{

    public class ReadAccountDto
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