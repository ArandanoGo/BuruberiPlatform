
namespace BURUBERI.CommunicationService.API.Domain.Model.Aggregates
{
    public class Contacto
    {
        public Guid Id { get; set; }                     // ID único del contacto
        public string IdDistribuidor { get; set; }       // ID del distribuidor
        public string IdProductor { get; set; }          // ID del productor

        // Constructor vacío
        public Contacto()
        {
            IdDistribuidor = string.Empty;
            IdProductor = string.Empty;
        }
    }
}