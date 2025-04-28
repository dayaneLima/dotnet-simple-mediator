using SimpleMediator.Core.Interfaces;

namespace SimpleApp;

public class NotificationHandler : INotificationHandler<PingRecebidoEvent>
{
    public Task Handle(PingRecebidoEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Notication] Message {notification.Message}");
        return Task.CompletedTask;
    }
}
