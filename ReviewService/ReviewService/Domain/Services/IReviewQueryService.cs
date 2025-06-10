using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.ReviewService.Domain.Model.Queries;

namespace ReviewService.ReviewService.Domain.Services;

public interface IReviewQueryService
{
    Task<IEnumerable<Review>?> Handle(GetAllReviewsQuery query);
    Task<Review?> Handle(GetReviewByIdQuery query);
}