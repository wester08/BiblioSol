

using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Persistence.Repositories
{
    public class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {

        private readonly BiblioContext _context;

        public LibroRepository(BiblioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OperationResult> AddAsync(Libro entity)
        {
            if (string.IsNullOrWhiteSpace(entity.titulo))
            {
                return OperationResult.Failure("El título del libro debe ser completado.");
            }

            if (entity.titulo.Length > 255)
            {
                return OperationResult.Failure("El título del libro no puede contener más de 255 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(entity.descripcion))
            {
                return OperationResult.Failure("La descripción del libro debe ser completada.");
            }

            if (entity.numeroPaginas <= 0)
            {
                return OperationResult.Failure("El número de páginas del libro debe ser completado.");
            }

            if (string.IsNullOrWhiteSpace(entity.isbn))
            {
                return OperationResult.Failure("El ISBN del libro debe ser completado.");
            }

            if (entity.isbn.Length > 20)
            {
                return OperationResult.Failure("El ISBN del libro no puede contener más de 20 caracteres.");
            }

            if (entity.autorId <= 0)
            {
                return OperationResult.Failure("El autor del libro debe ser completado.");
            }

            if (entity.editorialId <= 0)
            {
                return OperationResult.Failure("La editorial del libro debe ser completada.");
            }

            if (entity.anioPublicacion == default)
            {
                return OperationResult.Failure("El año de publicación del libro debe ser completado.");
            }

            if (entity.categoriaId <= 0)
            {
                return OperationResult.Failure("La categoría del libro debe ser completada.");
            }

            if (entity.precio <= 0)
            {
                return OperationResult.Failure("El precio del libro debe ser completado.");
            }

            if (entity.stock < 0)
            {
                return OperationResult.Failure("La cantidad (stock) de libros debe ser completada.");
            }

            if (string.IsNullOrWhiteSpace(entity.idioma))
            {
                return OperationResult.Failure("El idioma del libro debe ser completado.");
            }

            if (entity.idioma.Length > 50)
            {
                return OperationResult.Failure("El idioma del libro no puede contener más de 50 caracteres.");
            }

            if (entity.usuarioCreacionId <= 0)
            {
                return OperationResult.Failure("El usuario de creación del libro debe ser completado.");
            }

            var tituloExiste = await ExistsAsync(l => l.titulo == entity.titulo && l.active);
            if (tituloExiste)
            {
                return OperationResult.Failure($"El libro {entity.titulo} ya se encuentra registrado.");
            }

            var isbnExiste = await ExistsAsync(l => l.isbn == entity.isbn && l.active);
            if (isbnExiste)
            {
                return OperationResult.Failure($"El ISBN {entity.isbn} ya se encuentra registrado para otro libro.");
            }

            return await base.AddAsync(entity);
        }


        public override async Task<OperationResult> UpdateAsync(Libro entity)
        {
            if (entity.idLibro <= 0)
            {
                return OperationResult.Failure("El Id del libro debe ser mayor a cero.");
            }

            var libroExistente = await GetByIdAsync(entity.idLibro);
            if (!libroExistente.IsSuccess || libroExistente.Data is null)
            {
                return OperationResult.Failure("El libro no se encuentra registrado en la base de datos.");
            }

            if (string.IsNullOrWhiteSpace(entity.titulo))
            {
                return OperationResult.Failure("El título del libro debe ser completado.");
            }

            if (entity.titulo.Length > 255)
            {
                return OperationResult.Failure("El título del libro no puede contener más de 255 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(entity.descripcion))
            {
                return OperationResult.Failure("La descripción del libro debe ser completada.");
            }

            if (entity.numeroPaginas <= 0)
            {
                return OperationResult.Failure("El número de páginas del libro debe ser completado.");
            }

            if (string.IsNullOrWhiteSpace(entity.isbn))
            {
                return OperationResult.Failure("El ISBN del libro debe ser completado.");
            }

            if (entity.isbn.Length > 20)
            {
                return OperationResult.Failure("El ISBN del libro no puede contener más de 20 caracteres.");
            }

            if (entity.autorId <= 0)
            {
                return OperationResult.Failure("El autor del libro debe ser completado.");
            }

            if (entity.editorialId <= 0)
            {
                return OperationResult.Failure("La editorial del libro debe ser completada.");
            }

            if (entity.anioPublicacion == default)
            {
                return OperationResult.Failure("El año de publicación del libro debe ser completado.");
            }

            if (entity.categoriaId <= 0)
            {
                return OperationResult.Failure("La categoría del libro debe ser completada.");
            }

            if (entity.precio <= 0)
            {
                return OperationResult.Failure("El precio del libro debe ser completado.");
            }

            if (entity.stock < 0)
            {
                return OperationResult.Failure("La cantidad (stock) de libros debe ser completada.");
            }

            if (entity.estadoId <= 0)
            {
                return OperationResult.Failure("El estado del libro debe ser completado.");
            }

            if (string.IsNullOrWhiteSpace(entity.idioma))
            {
                return OperationResult.Failure("El idioma del libro debe ser completado.");
            }

            if (entity.idioma.Length > 50)
            {
                return OperationResult.Failure("El idioma del libro no puede contener más de 50 caracteres.");
            }

            if (entity.usuarioMod <= 0)
            {
                return OperationResult.Failure("El usuario que modifica el libro debe ser especificado.");
            }

            if (!string.Equals(entity.isbn, libroExistente.Data.isbn, StringComparison.OrdinalIgnoreCase))
            {
                var isbnDuplicado = await ExistsAsync(l => l.isbn == entity.isbn && l.idLibro != entity.idLibro && l.active);
                if (isbnDuplicado)
                {
                    return OperationResult.Failure($"El ISBN {entity.isbn} ya se encuentra registrado para otro libro.");
                }
            }

            if (!entity.active)
            {
                bool libroPrestado = await _context.Prestamos
                        .AnyAsync(p => p.libroId == entity.idLibro && p.active);
                if (libroPrestado)
                {
                    return OperationResult.Failure("No se puede desactivar el libro porque se encuentra prestado.");
                }
            }

            return await base.UpdateAsync(entity);
        }

    }
}
