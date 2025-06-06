using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir CreateLoteResource a CreateLoteCommand.
    /// </summary>
    public static class CreateLoteCommandFromResourceAssembler
    {
        public static CreateLoteCommand ToCommand(CreateLoteResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            return new CreateLoteCommand(
                autor: resource.Autor,
                hora: resource.Hora,
                materiaOrganica: resource.MateriaOrganica,
                cloruroPotasio: resource.CloruroPotasio,
                fosfato: resource.Fosfato,
                sulfatoCalcio: resource.SulfatoCalcio,
                urea: resource.Urea,
                sulfatoMagnesio: resource.SulfatoMagnesio,
                correctoresPH: resource.CorrectoresPH,
                idProductor: resource.IdProductor,
                tipo: resource.Tipo,
                pesoKg: resource.PesoKg,
                precioUnitario: resource.PrecioUnitario,
                calidad: resource.Calidad,
                estado: resource.Estado,
                stock: resource.Stock,
                fechaPedido: resource.FechaPedido,
                imagenUrl: resource.ImagenUrl
            );
        }
    }
}