namespace BURUBERI.InventoryService.API.Interface.REST.Resources;

/// <summary>
/// Resource for updating an existing Lot.
/// </summary>
public class UpdateLoteResource
{
    public string Type { get; set; }
    public double WeightKg { get; set; }
    public decimal UnitPrice { get; set; }
    public string Quality { get; set; }
    public string Status { get; set; }
    public double Stock { get; set; }
    public string LotNumber { get; set; }
    public DateTime ProducedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}