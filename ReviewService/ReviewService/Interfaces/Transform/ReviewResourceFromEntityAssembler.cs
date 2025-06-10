using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.ReviewService.Interfaces.Resources;

namespace ReviewService.ReviewService.Interfaces.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity) =>
        new ReviewResource(entity.Id, entity.LoteId, entity.Puntuacion, entity.Comentario);
}