using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Entities
{
    public class ProductExtraItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ProductExtraId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
