using SimpleMediator.Core.Interfaces;

namespace SimpleApp
{
    public record PingRecebidoEvent(string Message) : INotification;
}
