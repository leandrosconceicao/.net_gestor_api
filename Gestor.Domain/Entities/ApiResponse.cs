namespace Gestor.Domain.Entities
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public string? Tecnical { get; set; }
        public bool Result { get; set; } = true;
    }
}
