using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Queries;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;

namespace BURUBERI.InventoryService.API.Application.Internal.QueryServices;

public class LoteQueryService : ILoteQueryService
{
    private readonly ILoteRepository _repository;

    public LoteQueryService(ILoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Lot>> GetAllLotesAsync(GetAllLoteQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<Lot>> GetLotesByProducerAsync(GetAllLoteByProducerIdQuery query)
    {
        return await _repository.GetByProducerAsync(query.ProducerId);
    }
}