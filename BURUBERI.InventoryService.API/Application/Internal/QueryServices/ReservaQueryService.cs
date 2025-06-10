using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Queries;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;

namespace BURUBERI.InventoryService.API.Application.Internal.QueryServices;

public class ReservaQueryService : IReservaQueryService
{
    private readonly IReservaRepository _repository;

    public ReservaQueryService(IReservaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Reserva>> GetAllReservasAsync(GetAllReservaQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<Reserva>> GetReservasByProducerAsync(GetAllReservaByProductorIdQuery query)
    {
        return await _repository.GetByProductorAsync(query.IdProductor);
    }
    
    public async Task<IEnumerable<Reserva>> GetReservasByDistributorAsync(GetAllReservaByDistribuidorIdQuery query)
    {
        return await _repository.GetByDistribuidorAsync(query.IdDistribuidor);
    }
}