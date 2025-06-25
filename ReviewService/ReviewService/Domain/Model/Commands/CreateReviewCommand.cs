namespace ReviewService.ReviewService.Domain.Model.Commands;

public record CreateReviewCommand(Guid LoteId, int Puntuacion, string Comentario);