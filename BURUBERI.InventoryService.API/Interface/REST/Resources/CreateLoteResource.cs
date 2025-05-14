namespace BURUBERI.InventoryService.API.Interface.REST.Resources;

/// <summary>
/// Resource for creating a new Lot via API.
/// </summary>
public class CreateLoteResource
{
    public string ProducerId { get; set; }
    public string Type { get; set; }
    public double WeightKg { get; set; }
    public decimal UnitPrice { get; set; }
    public string Quality { get; set; }
    public double InitialStockKg { get; set; }
    public string LotNumber { get; set; }
    public DateTime ProducedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}