using Domain.RatingService.Model.Entities;
using Domain.RatingService.Model.Queries;

namespace Domain.RatingService.Services;

public interface IRatingQueryService
{
    Task<IEnumerable<Rating>?> Handle(GetAllRatingsQuery query);
    Task<Rating?> Handle(GetRatingByIdQuery query);
}