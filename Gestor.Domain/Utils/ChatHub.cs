using Gestor.Domain.Dtos;
using Gestor.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Gestor.Domain.Utils
{
    public class ChatHub(IChatHandler chatHandler) : Hub<IChatHub>
    {
        public async void SendMessage(string data)
        {
            await Clients.All.NotifyUsers(chatHandler.Parse(data));
        }
    }
}
