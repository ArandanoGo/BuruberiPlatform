using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.ReviewService.Domain.Model.Queries;
using ReviewService.ReviewService.Domain.Repositories;
using ReviewService.ReviewService.Domain.Services;

namespace ReviewService.ReviewService.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository)
    : IReviewQueryService
{
    public async Task<IEnumerable<Review>?> Handle(GetAllReviewsQuery query)
    {
        return await reviewRepository.ListAsync();
    }

    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.FindByIdAsync(query.Id);
    }
}