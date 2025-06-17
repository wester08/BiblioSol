

using BiblioSol.Application.DTOs.Library.Prestamo;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library
{
    public static class PrestamoExtension
    {
        public static Prestamo ToDomainEntityAdd(this PrestamoAddDto dto)
        {
            return new Prestamo
            {
                
                libroId = dto.libroId,
                nombreCliente = dto.nombreCliente,
                fechaCompromiso = dto.fechaCompromiso,
                estadoId = dto.estadoId,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active
            };
        }

        public static Prestamo ToDomainEntityAddReservar(this PrestamoAddDto dto)
        {
            return new Prestamo
            {

                libroId = dto.libroId,
                nombreCliente = dto.nombreCliente,
                fechaCompromiso = dto.fechaCompromiso,
                estadoId = 2,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active
            };
        }
        public static Prestamo ToDomainEntityUpdate(this PrestamoUpdateDto dto)
        {
            return new Prestamo
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
        public static PrestamoUpdateDto ToDto(this Prestamo entity)
        {
            return new PrestamoUpdateDto
            {
                idPrestamo = entity.idPrestamo,
                nombreCliente = entity.nombreCliente,
                libroId = entity.libroId,
                fechaCompromiso = entity.fechaCompromiso,
                fechaDevolucion = entity.fechaDevolucion,
                diasRetraso = entity.diasRetraso,
                monto = entity.monto,
                penalizado = entity.penalizado,
                estadoId = entity.estadoId,
                fechaMod = entity.fechaMod,
                usuarioMod = entity.usuarioMod,
                active = entity.active
            };
        }


    }
}
