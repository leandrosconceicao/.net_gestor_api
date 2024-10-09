using Gestor.Domain.Dtos.EstablishmentDtos;
using Gestor.Domain.Enums;

namespace Gestor.Domain.Dtos.UserDtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsActived { get; set; } = false;
        public int? Deleted { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

        public int EstablishmentId { get; set; }
        public virtual ReadEstablishmentDto Establishment { get; set; }
        public Role Role { get; set; }
    }
}
