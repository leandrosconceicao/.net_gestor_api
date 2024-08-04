using Api.Data.Dtos.EstablishmentDtos;
using Api.Models;

namespace Api.Data.Dtos.UserDtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsActived { get; set; } = false;
        public bool? IsDeleted { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public ReadEstablishmentDto Establishment { get; set; }
    }
}
