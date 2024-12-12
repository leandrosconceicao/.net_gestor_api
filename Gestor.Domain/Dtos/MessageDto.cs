using System.Text.Json.Serialization;

namespace Gestor.Domain.Dtos
{
    public class MessageDto()
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        public DateTime SentAt { get; } = DateTime.Now;
    }
}
