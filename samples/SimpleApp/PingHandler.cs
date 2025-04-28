using SimpleMediator.Core.Implementation;
using SimpleMediator.Core.Interfaces;

namespace SimpleApp;

public class PingHandler : IRequestHandler<PingRequest, string>
{
    private readonly IMediator _mediator;

    public PingHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<string> Handle(PingRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[RequestProccess] Message {request.Message}");
        await _mediator.Publish(new PingRecebidoEvent(request.Message), cancellationToken);
        return $"Request Processada: {request.Message}";
    }
}