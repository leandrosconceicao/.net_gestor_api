using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class ProductExtraItemDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ProductExtraId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
