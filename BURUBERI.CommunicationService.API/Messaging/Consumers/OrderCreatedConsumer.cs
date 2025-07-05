using System.Text;
using System.Text.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using BURUBERI.CommunicationService.API.Domain.Model.Commands;
using BURUBERI.CommunicationService.API.Domain.Services;

namespace BURUBERI.CommunicationService.API.Messaging.Consumers;

public class OrderCreatedConsumer : BackgroundService
{
    private readonly IModel _channel;
    private readonly IConnection _connection;
    private readonly IServiceScopeFactory _scopeFactory;

    public OrderCreatedConsumer(IConfiguration configuration, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;

        var factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMQ:Host"] ?? "rabbitmq"
        };

        // 👇 Nueva lógica con reintento
        _connection = ConnectWithRetry(factory);
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare("order_exchange", ExchangeType.Direct, durable: true);

        _channel.QueueDeclare(queue: "order.created", durable: false, exclusive: false, autoDelete: false, arguments: null);

        _channel.QueueBind(queue: "order.created", exchange: "order_exchange", routingKey: "order.created");
    }

    // 🔁 Método de reconexión con reintentos simples
    private IConnection ConnectWithRetry(ConnectionFactory factory, int maxRetries = 5, int delayMs = 3000)
    {
        int attempts = 0;

        while (true)
        {
            try
            {
                return factory.CreateConnection();
            }
            catch (Exception ex)
            {
                attempts++;
                Console.WriteLine($"❌ Error al conectar con RabbitMQ: {ex.Message}");
                if (attempts >= maxRetries)
                {
                    Console.WriteLine("💥 Límite de reintentos alcanzado. Lanzando excepción.");
                    throw;
                }

                Console.WriteLine($"🔁 Reintentando conexión ({attempts}/{maxRetries}) en {delayMs}ms...");
                Thread.Sleep(delayMs);
            }
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);

            var data = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

            if (data is not null)
            {
                using var scope = _scopeFactory.CreateScope();
                var contactoCommandService = scope.ServiceProvider.GetRequiredService<IContactoCommandService>();

                var command = new CreateContactoCommand(
                    data.IdDistribuidor.ToString(),
                    data.IdProductor.ToString()
                );

                await contactoCommandService.CreateContactoAsync(command);
            }
        };

        _channel.BasicConsume(queue: "order.created", autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }

    private class OrderCreatedEvent
    {
        public int IdDistribuidor { get; set; }
        public int IdProductor { get; set; }
    }
}
