using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Entities
{

    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Cgc { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<ClientAddress> Addresses { get; set; } = new List<ClientAddress>();
    }
}