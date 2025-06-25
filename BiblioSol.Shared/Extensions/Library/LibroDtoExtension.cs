

using BiblioSol.Shared.Dtos.LibrosDtos;

namespace BiblioSol.Shared.Extensions.Library
{
    public static class LibroDtoExtension
    {
        public static LibroUpdateDto ToUpdateLibroDto(this LibroDto dto)
        {
            return new LibroUpdateDto
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
    }
}
