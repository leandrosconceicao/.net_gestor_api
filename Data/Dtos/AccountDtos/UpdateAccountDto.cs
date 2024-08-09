using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Models;

namespace Api.Data.Dtos.AccountDtos {

    public class UpdateAccountDto
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
        public Client? Client { get; set; }
    }
}