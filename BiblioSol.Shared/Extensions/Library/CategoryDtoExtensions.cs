
using BiblioSol.Shared.Dtos.CategoryDtos;

namespace BiblioSol.Shared.Extensions
{
    public static class CategoryDtoExtensions
    {
        public static UpdateCategoryDto ToUpdateDto(this CategoryDto dto)
        {
            return new UpdateCategoryDto
            {
                idCategoria = dto.idCategoria,
                descripcion = dto.descripcion,
                fechaModificacion = dto.fechaMod,
                usuarioModificacionId = dto.usuarioMod,
                active = dto.active
            };
        }
    }
}
