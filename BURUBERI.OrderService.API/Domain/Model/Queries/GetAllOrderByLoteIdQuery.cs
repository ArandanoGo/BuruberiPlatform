namespace BURUBERI.OrderService.API.Domain.Model.Queries
{
    /// <summary>
    /// Consulta para obtener todas las órdenes por ID de lote.
    /// </summary>
    public class GetAllOrderByLoteIdQuery
    {
        public string IdLote { get; }

        public GetAllOrderByLoteIdQuery(string idLote)
        {
            if (string.IsNullOrWhiteSpace(idLote))
                throw new ArgumentNullException(nameof(idLote), "El ID del lote no puede estar vacío.");

            IdLote = idLote;
        }
    }
}