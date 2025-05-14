namespace Domain.RatingService.Model.Commands;

public record CreateRatingCommand(int Score, string Comment);