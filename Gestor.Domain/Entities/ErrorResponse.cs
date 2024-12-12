using Gestor.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Gestor.Domain.Entities
{
    public class ErrorResponse : IApiResponse
    {
        [JsonPropertyName("description")]
        public string Message { get; set; }
        [JsonPropertyName("tecnicalDescription")]
        public string? Tecnical { get; set; }
        [JsonPropertyName("result")]
        public bool Result { get; set; } = false;
    }
}
