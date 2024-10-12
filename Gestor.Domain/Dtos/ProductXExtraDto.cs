using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class ProductXExtraDto
    {
        public bool Required { get; set; } = false;

        [Required]
        public int ProductExtraId { get; set; }

        public int ProductId { get; set; }
    }
}
