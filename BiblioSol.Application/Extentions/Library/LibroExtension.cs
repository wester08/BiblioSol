

using BiblioSol.Application.DTOs.Library.Libro;
using BiblioSol.Domain.Entities;

namespace BiblioSol.Application.Extentions.Library
{
    public static class LibroExtension
    {
        public static Libro ToDomainEntityAdd(this LibroAddDto dto)
        {
            return new Libro
            {
                titulo = dto.titulo,
                descripcion = dto.descripcion,
                numeroPaginas = dto.numeroPaginas,
                isbn = dto.isbn,
                autorId = dto.autorId,
                editorialId = dto.editorialId,
                anioPublicacion = dto.anioPublicacion,
                categoriaId = dto.categoriaId,
                precio = dto.precio,
                stock = dto.stock,
                estadoId = dto.estadoId,
                idioma = dto.idioma,
                fechaCreacion = dto.fechaCreacion,
                usuarioCreacionId = dto.usuarioCreacionId,
                active = dto.active
            };
        }
        public static Libro ToDomainEntityUpdate(this LibroUpdateDto dto)
        {
            return new Libro
            {
                idLibro = dto.idLibro,
                titulo = dto.titulo,
                descripcion = dto.descripcion,
                numeroPaginas = dto.numeroPaginas,
                isbn = dto.isbn,
                autorId = dto.autorId,
                editorialId = dto.editorialId,
                anioPublicacion = dto.anioPublicacion,
                categoriaId = dto.categoriaId,
                precio = dto.precio,
                stock = dto.stock,
                estadoId = dto.estadoId,
                idioma = dto.idioma,
                fechaMod = dto.fechaMod,
                usuarioMod = dto.usuarioMod,
                active = dto.active
            };
        }
        public static LibroUpdateDto ToDto(this Libro entity)
        {
            return new LibroUpdateDto
            {
                idLibro = entity.idLibro,
                titulo = entity.titulo,
                descripcion = entity.descripcion,
                numeroPaginas = entity.numeroPaginas,
                isbn = entity.isbn,
                autorId = entity.autorId,
                editorialId = entity.editorialId,
                anioPublicacion = entity.anioPublicacion,
                categoriaId = entity.categoriaId,
                precio = entity.precio,
                stock = entity.stock,
                estadoId = entity.estadoId,
                idioma = entity.idioma,
                fechaMod = entity.fechaMod,
                usuarioMod = entity.usuarioMod,
                active = entity.active
            };
        }

    }
}
