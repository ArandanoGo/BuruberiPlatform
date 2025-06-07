namespace ReviewService.ReviewService.Domain.Model.Commands;

public record CreateReviewCommand(int LoteId, int Puntuacion, string Comentario);