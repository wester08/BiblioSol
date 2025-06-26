

using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Shared.Dtos.EditorialDtos;

namespace BiblioSol.Shared.Extensions.Library
{
    public static class EditorialExtension
    {
        public static EditorialUpdateDto ToUpdateEditorialDto(this EditorialDto dto)
        {
            return new EditorialUpdateDto
            {
                idEditorial = dto.idEditorial,
                nombre = dto.nombre,
                fechaMod = dto.fechaMod,
                usuarioMod = dto.usuarioMod,
                active = dto.active
            };
        }

    }
}






