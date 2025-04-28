using SimpleMediator.Core.Interfaces;

namespace SimpleApp;

public class PingRequest : IRequest<string>
{
    public string Message { get; set; } = "Ping!";
}
