
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
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active


            };
        }

        public static Categoria ToDomainEntityUpdate(this CategoriaUpdateDto dto)
        {

            return new Categoria
            {
                idCategoria = dto.idCategoria,
                descripcion = dto.descripcion,
                fechaMod = dto.fechaModificacion,
                usuarioMod = dto.usuarioModificacionId,
                active = dto.active

            };
        }

        public static CategoriaUpdateDto ToDto(this Categoria entity)
        {
            return new CategoriaUpdateDto
            {
                idCategoria = entity.idCategoria,
                descripcion = entity.descripcion,
                fechaModificacion = entity.fechaMod,
                usuarioModificacionId = entity.usuarioMod,
                active = entity.active

            };


        }
    }
}
