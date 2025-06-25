namespace ReviewService.ReviewService.Domain.Model.Aggregates;

public class Review
{
    public int Id { get; }
    
    public Guid LoteId { get; set; }
    
    public int Puntuacion { get; set; }
    
    public string Comentario { get; set; }
}