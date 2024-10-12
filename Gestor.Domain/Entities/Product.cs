using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        public double Price { get; set; }

        public bool HasProductExtraRequired { get; set; } = false;
        public bool RequirePreparation { get; set; } = false;
        public string ImagePath { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        public int EstablishmentId { get; set; }

        public int CategoryId { get; set; }

        public int? Deleted { get; set; }

        public virtual Establishment Establishment { get; set; }

        public virtual ProductCategory Category { get; set; }

        public ICollection<ProductCrossExtras> ProductExtras { get; set; } = [];

    }
}