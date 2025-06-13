
using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library.Category
{
    public static class CategoryExtension
    {
        public static Categoria ToCategoriaFromCategoriaDto(this CategoriaAddDto categoryAddDto)
        {
            return new Categoria
            {
                descripcion = categoryAddDto.descripcion,
                fechaCreacion = categoryAddDto.fechaCreacion,
                usuarioCreacionId = categoryAddDto.usuarioCreacionId


            };
        }


    
    }
}
