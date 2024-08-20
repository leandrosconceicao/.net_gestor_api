using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Domain.Entities
{
    public class Establishment
    {
        [Key]
        public int Id { get; set; }

        public int? Deleted { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public string LogoFilePath { get; set; } = string.Empty;

        public bool IsOpen { get; set; } = false;

        public string Address { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string PixKey { get; set; } = string.Empty;

        public string Instagram { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }
    }
}
