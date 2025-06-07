using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ReviewService.ReviewService.Domain.Model.Queries;
using ReviewService.ReviewService.Domain.Services;
using ReviewService.ReviewService.Interfaces.Resources;
using ReviewService.ReviewService.Interfaces.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace ReviewService.ReviewService.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Reviews")]
public class ReviewController(
    IReviewQueryService reviewQueryService,
    IReviewCommandService reviewCommandService)
: ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a review",
        Description = "Creates a specific review with.....",
        OperationId = "CreateReview")]
    [SwaggerResponse(201, 
        "The review was created.", typeof(ReviewResource))]
    [SwaggerResponse(400, 
        "The review was not created.")]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createReviewCommand =
            CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await reviewCommandService.Handle(createReviewCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetReviewById), new { id = result.Id },
            ReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a review by ID",
        Description = "Retrieves a specific review using its unique identifier.",
        OperationId = "GetReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK,
        "The review was found and returned successfully.", typeof(ReviewResource))]
    public async Task<ActionResult> GetReviewById(int id)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(id);
        var result = await reviewQueryService.Handle(getReviewByIdQuery);
        if (result is null) return NotFound();
        var resource =
            ReviewResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a review according to parameters",
        Description = "Get review for given parameters",
        OperationId = "GeAllReviews")]
    [SwaggerResponse(200, "Result(s) was/were found.", typeof(ReviewResource))]
    public async Task<ActionResult> GetAllReviews()
    {
        try
        {
            var getAllReviewsQuery = new GetAllReviewsQuery();
            var result = await reviewQueryService.Handle(getAllReviewsQuery);

            if (result != null && !result.Any()) return NotFound();

            var resource = result
                .Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity)
                .ToList();

            return Ok(resource);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}