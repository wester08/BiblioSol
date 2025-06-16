
using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library
{
    public static class EditorialExtension
    {
        public static Editorial ToDomainEntityAdd(this EditorialAddDto dto)
        {
            return new Editorial
            {
                nombre = dto.nombre,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active
            };
        }
        public static Editorial ToDomainEntityUpdate(this EditorialUpdateDto dto)
        {
            return new Editorial
            {
                idEditorial = dto.idEditorial,
                nombre = dto.nombre,
                fechaMod = dto.fechaMod,
                usuarioMod = dto.usuarioMod,
                active = dto.active
            };
        }
        public static EditorialUpdateDto ToDto(this Editorial entity)
        {
            return new EditorialUpdateDto
            {
                idEditorial = entity.idEditorial,
                nombre = entity.nombre,
                fechaMod = entity.fechaMod,
                usuarioMod = entity.usuarioMod,
                active = entity.active
            };
        }

    }
}
