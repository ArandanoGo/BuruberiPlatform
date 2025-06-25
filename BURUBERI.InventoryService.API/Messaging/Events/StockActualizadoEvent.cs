namespace BURUBERI.InventoryService.API.Messaging.Events;

public class StockActualizadoEvent
{
    public Guid LoteId { get; set; }
    public double NuevoStock { get; set; }
}