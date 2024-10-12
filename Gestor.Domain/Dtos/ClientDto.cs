using Gestor.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class ClientDto
    {
        public class Create()
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
}
