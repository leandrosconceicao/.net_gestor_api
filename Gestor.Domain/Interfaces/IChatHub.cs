using Gestor.Domain.Dtos;

namespace Gestor.Domain.Interfaces
{
    public interface IChatHub
    {
        Task NotifyUsers(MessageDto message);
    }
}
