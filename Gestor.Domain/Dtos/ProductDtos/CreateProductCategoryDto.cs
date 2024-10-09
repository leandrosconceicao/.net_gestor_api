using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos.ProductDtos;
public class CreateProductCategoryDto
{

    public string Description { get; set; }

    public string LogoPath { get; set; } = string.Empty;

    public int Ordenation { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Informe o ID do estabelecimento")]
    public int EstablishmentId { get; set; }

    // public virtual Establishment Establishment {get; set;}
}