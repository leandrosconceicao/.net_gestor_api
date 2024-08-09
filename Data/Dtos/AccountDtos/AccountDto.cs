using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Dtos.UserDtos;
using Api.Models;

namespace Api.Data.Dtos.AccountDtos {

    public class AccountDto
    {
        public int Id { get; set; }
        
        public string Description { get; set; }

        public AccountStatus Status { get; set; } = AccountStatus.Open;       
        
        public int UserId { get; set; }

        public virtual ReadUserDto User {get; set;}

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int EstablishmentId { get; set; }
        
        public virtual Establishment Establishment {get; set;}
        public Client? Client { get; set; } = new Client();
    }
}