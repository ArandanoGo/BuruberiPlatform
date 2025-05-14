using Domain.RatingService.Model.Commands;

namespace Domain.RatingService.Services;

public interface IRatingCommandService
{
    Task<int> Handle(CreateRatingCommand command);
}