using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost" }; // Usa "rabbitmq" si está en Docker
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "demo-exchange", type: ExchangeType.Fanout);

string message = "Hello Rabbit!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "demo-exchange",
                     routingKey: "",
                     basicProperties: null,
                     body: body);

Console.WriteLine("Mensaje enviado.");
