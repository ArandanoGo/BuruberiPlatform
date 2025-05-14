using Domain.Shared.Model.Entities;

namespace Domain.RatingService.Model.Entities;

public class Rating : ModelBase
{
    public int Score { get; set; }
    public string Comment { get; set; }
}