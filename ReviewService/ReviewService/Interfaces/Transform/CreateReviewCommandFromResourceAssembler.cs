using ReviewService.ReviewService.Domain.Model.Commands;
using ReviewService.ReviewService.Interfaces.Resources;

namespace ReviewService.ReviewService.Interfaces.Transform;

public class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource) =>
        new CreateReviewCommand(resource.LoteId, resource.Puntuacion, resource.Comentario);
}