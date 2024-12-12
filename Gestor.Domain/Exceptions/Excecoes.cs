using System.Net;

namespace Gestor.Domain.Exceptions
{
    public class NotFoundError : ExcecaoBase
    {
        public NotFoundError(string? message = null)
        {
            HttpStatus = HttpStatusCode.NotFound;
            Mensagem = message ?? "Registro não encontrado";
        }
    }

    public class DuplicateDataError : ExcecaoBase
    {
        public DuplicateDataError(string? message = null)
        {
            HttpStatus = HttpStatusCode.Conflict;
            Mensagem = message ?? "Registro duplicado";
        }
    }
}
