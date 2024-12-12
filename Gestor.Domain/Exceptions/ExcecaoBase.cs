using System.Net;

namespace Gestor.Domain.Exceptions
{
    public class ExcecaoBase : Exception
    {
        public string Mensagem { get; protected set; }
        public HttpStatusCode HttpStatus { get; protected set; }
        public string Excecao { get; protected set; }

        public override string Message { get {
                return Mensagem;
            }
        }
    }
}
