using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos.ProductDtos
{
    public class CreateProductXExtraDto
    {
        public bool Required { get; set; } = false;

        [Required]
        public int ProductExtraId { get; set; }

        public int ProductId { get; set; }
    }
}
