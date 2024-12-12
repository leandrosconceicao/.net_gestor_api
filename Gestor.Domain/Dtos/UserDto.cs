using Gestor.Domain.Enums;
using Gestor.Domain.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.Dtos
{
    public class UserDto
    {

        public class Login()
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class ReadUser()
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Name { get; set; }
            public bool IsActived { get; set; } = false;
            public int? Deleted { get; set; }
            public string Token { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime? UpdateAt { get; set; }
            public int EstablishmentId { get; set; }
            public virtual EstablishmentDto.ReadEstablishment Establishment { get; set; }
            public Role Role { get; set; }
        }
        public class CreateUser()
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
            public string Password
            {
                get
                {
                    return _password;
                }
                set
                {
                    _password = Crypto.GetHashedPassword(value);
                }
            }

            [Required(ErrorMessage = "username é campo obrigatório")]
            public string UserName { get; set; }
            public string Name { get; set; } = string.Empty;
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
            public Role Role { get; set; }
        }
        public class Update() {
            [Key]
            [Required]
            public int Id { get; set; }
            [Required(ErrorMessage = "email é campo obrigatório")]
            public string Email { get; set; }

            [Required(ErrorMessage = "password é campo obrigatório")]
            public string Password { get; set; }

            [Required(ErrorMessage = "username é campo obrigatório")]
            public string UserName { get; set; }
            public string Name { get; set; }
            public bool IsActived { get; set; } = false;
            public bool? IsDeleted { get; set; }
            public string Token { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime UpdateAt { get; set; }
            public int EstablishmentId { get; set; }
            public Role Role { get; set; }
        }
    }
}
