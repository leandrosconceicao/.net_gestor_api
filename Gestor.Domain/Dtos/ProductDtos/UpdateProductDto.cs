using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public double Price { get; set; }
        public bool HasProductExtraRequired { get; set; } = false;
        public bool RequirePreparation { get; set; } = false;
        public string ImagePath { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public ICollection<CreateProductXExtraDto> ProductExtras { get; set; } = [];
    }
}
