

using BiblioSol.Application.DTOs.Library.Autor;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library
{
    public static class AutorExtension
    {
        public static Autor ToDomainEntityAdd(this AutorAddDto dto)
        {
            return new Autor
            {
                nombre = dto.nombre,
                apellido = dto.apellido,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active
            };
        }
        public static Autor ToDomainEntityUpdate(this AutorUpdateDto dto)
        {
            return new Autor
            {
                idAutor = dto.idAutor,
                nombre = dto.nombre,
                apellido = dto.apellido,
                fechaMod = dto.fechaMod,
                usuarioMod = dto.usuarioMod,
                active = dto.active

            };
        }
        public static AutorUpdateDto ToDto(this Autor entity)
        {
            return new AutorUpdateDto
            {
                idAutor = entity.idAutor,
                nombre = entity.nombre,
                apellido = entity.apellido,
                fechaMod = entity.fechaMod,
                usuarioMod = entity.usuarioMod,
                active = entity.active
            };
        }



    }
}
