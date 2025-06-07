using ReviewService.Shared.Domain.Repositories;
using ReviewService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ReviewService.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}