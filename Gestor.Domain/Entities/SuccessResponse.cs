using Gestor.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Gestor.Domain.Entities
{
    public class SuccessResponse<T> : IApiResponse
    {
        [JsonPropertyName("description")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("tecnicalDescription")]
        public string? Tecnical { get; set; } = null;

        [JsonPropertyName("result")]
        public bool Result { get; set; } = true;
        
        [JsonPropertyName("dados")]
        public T Dados { get; set; }
    }
}
