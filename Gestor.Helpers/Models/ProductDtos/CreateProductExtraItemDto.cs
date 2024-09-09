using System.ComponentModel.DataAnnotations;

namespace Gestor.Helpers.Models.ProductDtos
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
