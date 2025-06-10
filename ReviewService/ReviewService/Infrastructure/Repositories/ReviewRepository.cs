using Microsoft.EntityFrameworkCore;
using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.ReviewService.Domain.Repositories;
using ReviewService.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReviewService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReviewService.ReviewService.Infrastructure.Repositories;

public class ReviewRepository(AppDbContext context)
    : BaseRepository<Review>(context), IReviewRepository
{
}