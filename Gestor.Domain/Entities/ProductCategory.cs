using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Entities
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(32, ErrorMessage = "Tamanho máximo excedido")]
        public string Description { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public int Ordenation { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        public int EstablishmentId { get; set; }

        public virtual Establishment Establishment { get; set; }
    }
}
