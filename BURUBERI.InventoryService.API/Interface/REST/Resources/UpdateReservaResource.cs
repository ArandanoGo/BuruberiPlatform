namespace BURUBERI.InventoryService.API.Interface.REST.Resources;

public class UpdateReservaResource
{
    public string IdDistribuidor { get; set; } = string.Empty;
    public string IdLote { get; set; } = string.Empty;
    public string IdProductor { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
    public double Stock { get; set; }
    public string Estado { get; set; } = string.Empty;
}
