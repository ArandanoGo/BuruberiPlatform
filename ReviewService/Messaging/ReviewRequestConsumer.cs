using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReviewService.ReviewService.Domain.Model.Queries;
using ReviewService.ReviewService.Domain.Services;

namespace ReviewService.Messaging;

public class ReviewRequestConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private IConnection _connection;
    private IModel _channel;
    private readonly string _exchange = "review-requests-exchange";
    private readonly string _queue = "review-request-queue";
    private readonly string _routingKey = "get-reviews-by-lote";

    public ReviewRequestConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        var factory = new ConnectionFactory { HostName = "rabbitmq" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(_exchange, ExchangeType.Direct, durable: true);
        _channel.QueueDeclare(_queue, durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind(_queue, _exchange, _routingKey);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            using var scope = _serviceProvider.CreateScope();
            var queryService = scope.ServiceProvider.GetRequiredService<IReviewQueryService>();

            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            try
            {
                var data = JsonSerializer.Deserialize<ReviewRequestMessage>(message);
                if (data is null)
                {
                    Console.WriteLine("❌ No se pudo deserializar el mensaje.");
                    return;
                }

                var query = new GetReviewsByLoteIdQuery(data.LoteId);
                var reviews = await queryService.Handle(query);
                Console.WriteLine($"📥 Solicitud recibida para lote {data.LoteId}, se encontraron {reviews.Count()} reseñas.");

                // ✅ Solo hacer ACK si todo va bien
                _channel.BasicAck(ea.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error procesando el mensaje: {ex.Message}");
                // ❌ No hacemos ACK, el mensaje queda como Unacked
            }
        };

        _channel.BasicConsume(_queue, autoAck: false, consumer: consumer);
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}

// Clase para mapear el mensaje recibido
public class ReviewRequestMessage
{
    public Guid LoteId { get; set; }
}
