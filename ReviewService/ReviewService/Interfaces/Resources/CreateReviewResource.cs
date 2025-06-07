namespace ReviewService.ReviewService.Interfaces.Resources;

public record CreateReviewResource(int LoteId, int Puntuacion, string Comentario);