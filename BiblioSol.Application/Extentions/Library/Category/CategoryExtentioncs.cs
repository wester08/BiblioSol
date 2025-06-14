
using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library.Category
{
    public static class CategoryExtension
    {
        public static Categoria ToDomainEntityAdd(this CategoriaAddDto dto)
        {
           
            return new Categoria
            {
                descripcion = dto.descripcion,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId


            };
        }

        public static Categoria ToDomainEntityUpdate(this CategoriaUpdateDto dto)
        {

            return new Categoria
            {
                idCategoria = dto.idCategoria,
                descripcion = dto.descripcion,
                fechaModificacion = dto.fechaModificacion,
                usuarioModificacionId = dto.usuarioModificacionId




            };
        }

        public static CategoriaUpdateDto ToDto(this Categoria entity)
        {
            return new CategoriaUpdateDto
            {
                idCategoria = entity.idCategoria,
                descripcion = entity.descripcion,
                fechaModificacion = entity.fechaModificacion,
                usuarioModificacionId = entity.usuarioModificacionId

            };


        }
    }
}
