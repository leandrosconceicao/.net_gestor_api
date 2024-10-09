using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos.ProductDtos
{
    public class CreateProductExtratoDto
    {
        [Required]
        public string Name { get; set; }
        public double MaxQtdAllowed { get; set; }
        public bool Required { get; set; } = false;

        [Required]
        public int EstablishmentId { get; set; }
        public ICollection<CreateProductExtraItemDto> Items { get; set; } = [];
    }
}
