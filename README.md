
# Simple Mediator

Uma implementação **leve**, **fácil de usar** e **gratuita** do padrão **Mediator** para aplicações .NET.

> O projeto nasceu como alternativa ao **MediatR**, que passou a ter versão paga.

---

## ✨ Features

- **Envio de comandos e consultas** (`Send`)
- **Publicação de notificações** (`Publish`)
- **Integração nativa com `Microsoft.Extensions.DependencyInjection`**
- **Sem dependências externas**

---

## 🚀 Instalação

Adicione a referência ao seu projeto:

```bash
git clone https://github.com/dayaneLima/dotnet-simple-mediator.git
```

Depois, adicione os serviços no seu `Startup` ou `Program.cs`:

```csharp
builder.Services.AddSimpleMediator(typeof(Program).Assembly);
```

---

## 💻 Como Usar

### Criando uma Request

```csharp
public class Ping : IRequest<string>
{
    public string Message { get; set; }
}
```

### Criando um Handler para a Request

```csharp
public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"Recebido: {request.Message}");
    }
}
```

### Enviando a Request

```csharp
var response = await _mediator.Send(new Ping { Message = "Olá, Mediator!" });
Console.WriteLine(response); // Saída: Recebido: Olá, Mediator!
```

---

### Publicando uma Notification

```csharp
public class AlertNotification : INotification
{
    public string AlertMessage { get; set; }
}
```

```csharp
public class AlertNotificationHandler : INotificationHandler<AlertNotification>
{
    public Task Handle(AlertNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Alerta recebido: {notification.AlertMessage}");
        return Task.CompletedTask;
    }
}
```

```csharp
await _mediator.Publish(new AlertNotification { AlertMessage = "Nova notificação!" });
```

---

## 🛠️ Como Funciona

Internamente, o `Mediator`:

- Resolve dinamicamente o **handler** para uma `Request`.
- Invoca o método `Handle` usando **reflection**.
- Garante que todas as **notificações** sejam tratadas por **todos os handlers** registrados.

Código base do `Mediator`:

```csharp
public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
{ 
    // Encontra e executa o handler correto para a request
}

public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
{
    // Encontra e executa todos os handlers da notificação
}
```

---

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).

---

# 📢 Aviso

Este é um projeto educacional, mas totalmente utilizável em pequenos e médios projetos de produção.  
Para grandes aplicações com alta performance, pode ser necessário ajustar/refinar para casos mais específicos.
