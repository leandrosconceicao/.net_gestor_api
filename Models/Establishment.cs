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

        public string LogoFilePath { get; set; } = "";

        public bool IsOpen { get; set; } = false;

        public string Address { get; set; } = "";

        public string Url { get; set; } = "";

        public string PixKey { get; set; } = "";


    }
}
