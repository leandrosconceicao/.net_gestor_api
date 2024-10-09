using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos.ProductDtos
{
    public class CreateProductExtraItemDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ProductExtraId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
