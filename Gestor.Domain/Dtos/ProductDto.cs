using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class ProductDto
    {
        public class CreateProduct()
        {
            [Required]
            [StringLength(32)]
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;

            [Required]
            [Range(.01, double.MaxValue, ErrorMessage = "Informe um valor maior que 0.01")]
            public double Price { get; set; }

            public bool HasProductExtraRequired { get; set; } = false;
            public bool RequirePreparation { get; set; } = false;
            public string ImagePath { get; set; } = string.Empty;

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Identificação do estabelecimento é obrigatório")]
            public int EstablishmentId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Informe o ID da categoria")]
            public int CategoryId { get; set; }

            public ICollection<ProductXExtraDto> ProductExtras { get; set; } = [];
        }
        public class UpdateProduct()
        {
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;
            public double Price { get; set; }
            public bool HasProductExtraRequired { get; set; } = false;
            public bool RequirePreparation { get; set; } = false;
            public string ImagePath { get; set; } = string.Empty;
            public int CategoryId { get; set; }
            public ICollection<ProductXExtraDto> ProductExtras { get; set; } = [];
        }
    }
}
