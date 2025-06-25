namespace ReviewService.ReviewService.Interfaces.Resources;

public record CreateReviewResource(Guid LoteId, int Puntuacion, string Comentario);