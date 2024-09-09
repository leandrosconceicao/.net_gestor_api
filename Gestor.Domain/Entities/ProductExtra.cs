using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Entities
{
    public class ProductExtra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double MaxQtdAllowed { get; set; }
        //public bool Required { get; set; } = false;

        [Required]
        public int EstablishmentId { get; set; }
        public ICollection<ProductExtraItem> Items { get; set; } = [];

    }
}