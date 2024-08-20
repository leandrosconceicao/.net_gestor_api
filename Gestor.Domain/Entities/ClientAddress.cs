using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Entities
{

    public class ClientAddress
    {

        [Key]
        public int Id { get; set; }

        public string PublicPlace { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Complement { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public int ClientId { get; set; }

        // public virtual Client Client { get; set; }

    }
}