namespace BURUBERI.OrderService.API.Messaging.Events;

public class OrderCreatedEvent
{
    public int IdDistribuidor { get; set; }
    public int IdProductor { get; set; }
}
