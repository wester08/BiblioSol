

using BiblioSol.Shared.Dtos.EstadoDtos;
using BiblioSol.Shared.Dtos.PrestamosDtos;

namespace BiblioSol.Shared.Extensions.Library
{
    public static class EstadoExtensions
    {
        public static EstadoUpdateDto ToUpdateEstadoDto(this EstadoDto dto)
        {
            return new EstadoUpdateDto
            {
                idEstado = dto.idEstado,
                nombre = dto.nombre,
                fechaModificacion = dto.fechaMod,
                usuarioModificionId = dto.usuarioMod,
                active = dto.active
            };
        }

    }
}
