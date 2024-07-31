using System.ComponentModel.DataAnnotations;

namespace Api.Models.Base
{
    public abstract class UserBase
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public bool IsActived { get; set; }

        public bool ChangePassword { get; set; }
        public bool? IsDeleted { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public int EstablishmentId { get; set; }

        public virtual Establishment Establishment { get; set; }
    }
}
