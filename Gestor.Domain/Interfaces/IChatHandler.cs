using Gestor.Domain.Dtos;

namespace Gestor.Domain.Interfaces
{
    public interface IChatHandler
    {
        MessageDto Parse(string data);


    }
}
