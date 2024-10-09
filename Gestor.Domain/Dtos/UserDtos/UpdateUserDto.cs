using Gestor.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "email é campo obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password é campo obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "username é campo obrigatório")]
        public string UserName { get; set; }

        public bool IsActived { get; set; } = false;
        public bool? IsDeleted { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; }

        public int EstablishmentId { get; set; }
        public Role Role { get; set; }
    }
}
