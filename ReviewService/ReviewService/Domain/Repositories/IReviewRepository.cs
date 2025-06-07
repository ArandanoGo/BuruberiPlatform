using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.Shared.Domain.Repositories;

namespace ReviewService.ReviewService.Domain.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
}