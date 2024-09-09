using System.ComponentModel.DataAnnotations;

namespace Gestor.Helpers.Models.ProductDtos
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
