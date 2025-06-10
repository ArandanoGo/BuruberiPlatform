using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.ReviewService.Domain.Model.Commands;
using ReviewService.ReviewService.Domain.Repositories;
using ReviewService.ReviewService.Domain.Services;
using ReviewService.Shared.Domain.Repositories;

namespace ReviewService.ReviewService.Application.Internal.CommandServices;

public class ReviewCommandService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    : IReviewCommandService
{
    public async Task<Review?> Handle(CreateReviewCommand command)
    {
        var review = new Review
        {
            LoteId = command.LoteId,
            Puntuacion = command.Puntuacion,
            Comentario = command.Comentario
        };
        
        await reviewRepository.AddAsync(review);
        await unitOfWork.CompleteAsync();

        return review;
    }
}