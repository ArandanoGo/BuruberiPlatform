using Domain.RatingService.Model.Commands;
using Domain.RatingService.Model.Entities;
using Domain.RatingService.Repositories;
using Domain.RatingService.Services;
using Domain.Shared;

namespace Application.RatingService.CommandServices;

public class RatingCommandService : IRatingCommandService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RatingCommandService(IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
    {
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRatingCommand command)
    {
        var rating = new Rating
        {
            Score = command.Score,
            Comment = command.Comment
        };
        
        await _ratingRepository.AddAsync(rating);
        await _unitOfWork.CompleteAsync();
        return rating.Id;
    }
}