

using BiblioSol.Application.DTOs.Library.Estado;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library
{
    public static class EstadoExtension
    {
        public static Estado ToDomainEntityAdd(this EstadoAddDto dto)
        {
            return new Estado
            {
                nombre = dto.nombre,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active
            };
        }
        public static Estado ToDomainEntityUpdate(this EstadoUpdateDto dto)
        {
            return new Estado
            {
                idEstado = dto.idEstado,
                nombre = dto.nombre,
                fechaMod = dto.fechaModificacion,
                usuarioMod = dto.usuarioModificionId,
                active = dto.active
            };
        }
        public static EstadoUpdateDto ToDto(this Estado entity)
        {
            return new EstadoUpdateDto
            {
                idEstado = entity.idEstado,
                nombre = entity.nombre,
                fechaModificacion = entity.fechaMod,
                usuarioModificionId = entity.usuarioMod,
                active = entity.active
            };
        }
    }
}
