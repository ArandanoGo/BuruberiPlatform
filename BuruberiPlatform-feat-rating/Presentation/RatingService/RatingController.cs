using Domain.RatingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.RatingService;

public class RatingController(IRatingQueryService ratingQueryService, IRatingCommandService ratingCommandService) : ControllerBase
{
}