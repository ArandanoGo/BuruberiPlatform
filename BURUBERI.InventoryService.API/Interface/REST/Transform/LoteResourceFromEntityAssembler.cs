using System;
using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir la entidad Lote a LoteResource.
    /// </summary>
    public static class LoteResourceFromEntityAssembler
    {
        public static LoteResource ToResource(Lote entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new LoteResource
            {
                Id = entity.Id,
                Autor = entity.Autor,
                FechaRegistro = entity.FechaRegistro,
                Hora = entity.Hora,

                MateriaOrganica = entity.MateriaOrganica,
                CloruroPotasio = entity.CloruroPotasio,
                Fosfato = entity.Fosfato,
                SulfatoCalcio = entity.SulfatoCalcio,
                Urea = entity.Urea,
                SulfatoMagnesio = entity.SulfatoMagnesio,
                CorrectoresPH = entity.CorrectoresPH,

                IdProductor = entity.IdProductor,
                Tipo = entity.Tipo,
                PesoKg = entity.PesoKg,
                PrecioUnitario = entity.PrecioUnitario,
                Calidad = entity.Calidad,
                Estado = entity.Estado,
                Stock = entity.Stock,

                FechaPedido = entity.FechaPedido,
                ImagenUrl = entity.ImagenUrl,

                FechaCreacion = entity.FechaCreacion,
                FechaActualizacion = entity.FechaActualizacion
            };
        }
    }
}