namespace ReviewService.ReviewService.Interfaces.Resources;

public record ReviewResource(int Id, Guid LoteId, int Puntuacion, string Comentario);