using GestorUtils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Helpers.Models.UserDtos
{
    public class CreateUserDto
    {
        private string _password;

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "email é campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "password é campo obrigatório")]
        [DataType(DataType.Password)]
        public string Password {
            get
            {
                return _password;
            }
            set { 
                _password = CryptoService.GetHashedPassword(value);
            } 
        }

        [Required(ErrorMessage = "username é campo obrigatório")]
        public string UserName { get; set; }

        public bool IsActived { get; set; } = true;

        public bool ChangePassword { get; set; } = false;
        public string Token { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdateAt { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Identificação do estabelecimento é obrigatório")]
        public int EstablishmentId { get; set; }

        public int RoleId { get; set; }
    }
}
