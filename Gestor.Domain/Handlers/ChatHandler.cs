using Gestor.Domain.Dtos;
using Gestor.Domain.Interfaces;
using Newtonsoft.Json;

namespace Gestor.Domain.Handlers
{
    public class ChatHandler : IChatHandler
    {
        public MessageDto Parse(string data)
        {
            return JsonConvert.DeserializeObject<MessageDto>(data) 
                ?? throw new Exception("Dados inválidos");
        }
    }
}
