using SimpleMediator.Core.Interfaces;

namespace SimpleApp;

public class Notification2Handler : INotificationHandler<PingRecebidoEvent>
{
    public Task Handle(PingRecebidoEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Notication 2] Message {notification.Message}");
        return Task.CompletedTask;
    }
}
