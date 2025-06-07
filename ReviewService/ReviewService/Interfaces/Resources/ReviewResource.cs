namespace ReviewService.ReviewService.Interfaces.Resources;

public record ReviewResource(int Id, int LoteId, int Puntuacion, string Comentario);