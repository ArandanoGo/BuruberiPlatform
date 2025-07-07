using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace BURUBERI.InventoryService.API.Messaging;

public class EventBusPublisher : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventBusPublisher()
    {
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq",
            DispatchConsumersAsync = true 
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        // Declarar todos los exchanges que podrías usar
        _channel.ExchangeDeclare(exchange: "lotes-exchange", type: ExchangeType.Fanout, durable: true);
        _channel.ExchangeDeclare(exchange: "review-requests-exchange", type: ExchangeType.Direct, durable: true);
    }

    public void Publish(string exchange, string routingKey, object evento)
    {
        var message = JsonSerializer.Serialize(evento);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(
            exchange: exchange,
            routingKey: routingKey,
            basicProperties: null,
            body: body
        );

        Console.WriteLine($"✅ Mensaje publicado en el exchange '{exchange}' con routing key '{routingKey}'");
    }


    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}