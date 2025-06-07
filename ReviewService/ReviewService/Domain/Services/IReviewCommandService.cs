using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.ReviewService.Domain.Model.Commands;

namespace ReviewService.ReviewService.Domain.Services;

public interface IReviewCommandService
{
    Task<Review?> Handle(CreateReviewCommand command);
}