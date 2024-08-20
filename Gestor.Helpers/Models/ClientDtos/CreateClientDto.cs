using Gestor.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Helpers.Models.ClientDtos
{
    public class CreateClientDto
    {

        [StringLength(14, MinimumLength = 11, ErrorMessage = "Tamanho inválido")]
        public string Cgc { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<ClientAddress> Addresses { get; set; } = [];
    }
}
