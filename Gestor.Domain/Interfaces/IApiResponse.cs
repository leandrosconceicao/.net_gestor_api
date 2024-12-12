using System.Text.Json.Serialization;

namespace Gestor.Domain.Interfaces
{
    public interface IApiResponse
    {
        public string Message { get; set; }

        public string? Tecnical { get; set; }

        public bool Result { get; set; }
    }
}
