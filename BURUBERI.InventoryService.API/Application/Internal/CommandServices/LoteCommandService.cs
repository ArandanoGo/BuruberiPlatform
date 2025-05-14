using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;

namespace BURUBERI.InventoryService.API.Application.Internal.CommandServices;

public class LoteCommandService : ILoteCommandService
{
    private readonly ILoteRepository _repository;

    public LoteCommandService(ILoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Lot> CreateLoteAsync(CreateLoteCommand command)
    {
        // Map command to domain entity
        var lote = new Lot
        {
            Id = Guid.NewGuid(),
            ProducerId = command.ProducerId,
            Type = command.Type,
            WeightKg = command.WeightKg,
            UnitPrice = command.UnitPrice,
            Quality = command.Quality,
            Status = "Disponible",       // Default status
            Stock = command.InitialStockKg,
            LotNumber = command.LotNumber,
            ProducedAt = command.ProducedAt,
            ExpiresAt = command.ExpiresAt,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await _repository.AddAsync(lote);
    }
}