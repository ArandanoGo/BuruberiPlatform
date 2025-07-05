using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace BURUBERI.OrderService.API.Messaging;

public class EventBusPublisher
{
    private readonly IModel _channel;

    public EventBusPublisher(IConfiguration configuration)
    {
        var factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMQ:Host"] ?? "localhost"
        };

        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        
        
        _channel.ExchangeDeclare("order_exchange", ExchangeType.Direct, durable: true);

        _channel.QueueDeclare(queue: "order.created", durable: false, exclusive: false, autoDelete: false, arguments: null);

        _channel.QueueBind(queue: "order.created", exchange: "order_exchange", routingKey: "order.created");
    }

    public void PublishOrderCreated(int idDistribuidor, int idProductor)
    {
        var evento = new
        {
            IdDistribuidor = idDistribuidor,
            IdProductor = idProductor
        };

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(evento));
        
        _channel.BasicPublish(exchange: "order_exchange", routingKey: "order.created", basicProperties: null, body: body);
    }
}