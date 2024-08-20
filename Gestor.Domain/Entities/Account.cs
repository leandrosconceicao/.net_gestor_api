using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Domain.Entities
{

    public class Account
    {
        [Key]
        public int Id { get; set; }

        public int Deleted { get; set; }
        public string Description { get; set; } = string.Empty;
        
        [EnumDataType(typeof(AccountStatus), ErrorMessage = "Status inválido, Valores permitidos: (0) - open, (1) - closed, (2) - hold")]
        public AccountStatus Status { get; set; } = AccountStatus.Open;
        
        [Range(1, int.MaxValue, ErrorMessage = "Informe o ID do usuário")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? UpdatedAt { get; set; }
        public int EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual Client Client { get; set; }
    }

    public enum AccountStatus
    {
        Open = 0,
        Closed = 1,
        Hold = 2
    }
}