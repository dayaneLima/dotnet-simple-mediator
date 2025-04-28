using SimpleApp;
using SimpleMediator.Core.Extensions;
using SimpleMediator.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSimpleMediator(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", async (IMediator mediator) =>
{
    var result = await mediator.Send(new PingRequest { Message = "Hello Simple Mediator" });
    return Results.Ok(result);
});

app.Run();