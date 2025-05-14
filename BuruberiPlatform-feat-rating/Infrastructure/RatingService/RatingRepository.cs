using Domain.RatingService.Model.Entities;
using Domain.RatingService.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.RatingService;

public class RatingRepository(AppDbContext context) : BaseRepository<Rating>(context), IRatingRepository
{
}