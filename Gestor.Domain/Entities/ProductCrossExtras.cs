using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Entities
{
    public class ProductCrossExtras
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductExtraId { get; set; }

        public int ProductId { get; set; }

        public virtual ProductExtra ProductCrossExtra { get; set; }
    }
}
