using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Establishment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
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
    }
}
