namespace BURUBERI.InventoryService.API.Interface.REST.Resources;

/// <summary>
/// Resource representing a Lot returned by the API.
/// </summary>
public class LoteResource
{
    public Guid Id { get; set; }
    public string ProducerId { get; set; }
    public string Type { get; set; }
    public double WeightKg { get; set; }
    public decimal UnitPrice { get; set; }
    public string Quality { get; set; }
    public string Status { get; set; }
    public double Stock { get; set; }
    public string LotNumber { get; set; }
    public DateTime ProducedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}