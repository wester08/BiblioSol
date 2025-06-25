using BiblioSol.Shared.Dtos.PrestamosDtos;

namespace BiblioSol.Shared.Extensions.Library
{
    public static class PrestamoDtoExtensions
    {
        public static PrestamoUpdateDto ToUpdatePrestamoDto(this PrestamoDto dto)
        {
            return new PrestamoUpdateDto
            {
                idPrestamo = dto.idPrestamo,
                nombreCliente = dto.nombreCliente,
                libroId = dto.libroId,
                fechaCompromiso = dto.fechaCompromiso,
                fechaDevolucion = dto.fechaDevolucion,
                diasRetraso = dto.diasRetraso,
                monto = dto.monto,
                penalizado = dto.penalizado,
                estadoId = dto.estadoId,
                fechaMod = dto.fechaMod,
                usuarioMod = dto.usuarioMod,
                active = dto.active

            };
        }
    }
}

