
using BiblioSol.Shared.Dtos.AutorDtos;

namespace BiblioSol.Shared.Extensions.Library
{
    public static class AutorDtoExtensions
    {
        public static AutorUpdateDto ToUpdateAutorDto(this AutorDto dto)
        {
            return new AutorUpdateDto
            {
                idAutor = dto.idAutor,
                nombre = dto.nombre,
                apellido = dto.apellido,
                fechaMod = dto.fechaMod,
                usuarioMod = dto.usuarioMod,
                active = dto.active
            };
        }
    }
}




