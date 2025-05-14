using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

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
    
    public async Task<Lot> UpdateLoteAsync(Guid id, UpdateLoteResource resource)
    {
        var lote = await _repository.GetByIdAsync(id);
        if (lote == null) throw new KeyNotFoundException("Lote not found.");
        // map fields
        lote.Type = resource.Type;
        lote.WeightKg = resource.WeightKg;
        lote.UnitPrice = resource.UnitPrice;
        lote.Quality = resource.Quality;
        lote.Status = resource.Status;
        lote.Stock = resource.Stock;
        lote.LotNumber = resource.LotNumber;
        lote.ProducedAt = resource.ProducedAt;
        lote.ExpiresAt = resource.ExpiresAt;
        lote.UpdatedAt = DateTime.UtcNow;

        return await _repository.UpdateAsync(lote);
    }

    public async Task DeleteLoteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
    
}