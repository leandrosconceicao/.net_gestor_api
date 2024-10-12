using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class ProductExtraDto
    {
        [Required]
        public string Name { get; set; }
        public double MaxQtdAllowed { get; set; }
        public bool Required { get; set; } = false;

        [Required]
        public int EstablishmentId { get; set; }
        public ICollection<ProductExtraItemDto> Items { get; set; } = [];
    }
}
