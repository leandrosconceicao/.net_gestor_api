using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.EstablishmentDtos
{
    public class ReadEstablishmentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public string LogoFilePath { get; set; }

        public bool IsOpen { get; set; } = false;

        public string Address { get; set; }

        public string Url { get; set; }

        public string PixKey { get; set; }
    }
}
