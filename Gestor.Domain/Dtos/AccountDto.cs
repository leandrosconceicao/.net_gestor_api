using Gestor.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class AccountDto
    {
        public class ReadAccount()
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public AccountStatus Status { get; set; } = AccountStatus.Open;

            public int UserId { get; set; }

            public virtual UserDto.ReadUser User { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime? UpdatedAt { get; set; }

            public int EstablishmentId { get; set; }

            public virtual EstablishmentDto.ReadEstablishment Establishment { get; set; }
            public ClientDto.ReadClient? Client { get; set; } = new ClientDto.ReadClient();
        }
        public class UpdateAccount()
        {
            public string? Description { get; set; }

            public AccountStatus? Status { get; set; }

            public int? UserId { get; set; }
            public ClientDto.UpdateClient? Client { get; set; }
        }
        public class CreateAccount()
        {
            public string? Description { get; set; }

            [EnumDataType(typeof(AccountStatus), ErrorMessage = "Status inválido, Valores permitidos: (0) - open, (1) - closed, (2) - hold")]
            public AccountStatus Status { get; set; }
            public int UserId { get; set; }

            [DataType(DataType.DateTime)]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public DateTime? UpdatedAt { get; set; } = DateTime.Now;

            [Range(1, int.MaxValue, ErrorMessage = "Informe o ID do estabelecimento")]
            public int EstablishmentId { get; set; }
            public ClientDto.CreateClient? Client { get; set; } = new ClientDto.CreateClient();
        }
    }
}
