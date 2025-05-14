namespace BURUBERI.InventoryService.API.Domain.Model.Commands;

/// <summary>
/// Command to create a new Lot aggregate.
/// </summary>
public class CreateLoteCommand
{
    public string ProducerId { get; }
    public string Type { get; }
    public double WeightKg { get; }
    public decimal UnitPrice { get; }
    public string Quality { get; }
    public double InitialStockKg { get; }
    public string LotNumber { get; }
    public DateTime ProducedAt { get; }
    public DateTime ExpiresAt { get; }

    public CreateLoteCommand(
        string producerId,
        string type,
        double weightKg,
        decimal unitPrice,
        string quality,
        double initialStockKg,
        string lotNumber,
        DateTime producedAt,
        DateTime expiresAt)
    {
        ProducerId = producerId;
        Type = type;
        WeightKg = weightKg;
        UnitPrice = unitPrice;
        Quality = quality;
        InitialStockKg = initialStockKg;
        LotNumber = lotNumber;
        ProducedAt = producedAt;
        ExpiresAt = expiresAt;
    }
}