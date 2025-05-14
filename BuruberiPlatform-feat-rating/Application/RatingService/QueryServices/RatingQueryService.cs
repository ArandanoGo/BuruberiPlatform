using Domain.RatingService.Model.Entities;
using Domain.RatingService.Model.Queries;
using Domain.RatingService.Repositories;
using Domain.RatingService.Services;

namespace Application.RatingService.QueryServices;

public class RatingQueryService : IRatingQueryService
{
    private readonly IRatingRepository _repository;

    public RatingQueryService(IRatingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Rating>?> Handle(GetAllRatingsQuery query)
    {
        return await _repository.ListAsync();
    }

    public async Task<Rating?> Handle(GetRatingByIdQuery query)
    {
        return await _repository.FindByIdAsync(query.Id);
    }
}