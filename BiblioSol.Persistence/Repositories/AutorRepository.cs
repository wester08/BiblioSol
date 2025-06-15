
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Persistence.Repositories
{
    public sealed class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        private readonly BiblioContext _context;

        public AutorRepository(BiblioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OperationResult> AddAsync(Autor entity)
        {
            if (string.IsNullOrWhiteSpace(entity.nombre))
                return OperationResult.Failure("El Nombre del autor debe ser completado.");

            if (string.IsNullOrWhiteSpace(entity.apellido))
                return OperationResult.Failure("El Apellido del autor debe ser completado.");

            if (entity.nombre.Length > 50)
                return OperationResult.Failure("El nombre del autor no puede contener más de 50 caracteres.");

            if (entity.apellido.Length > 50)
                return OperationResult.Failure("El apellido del autor no puede contener más de 50 caracteres.");

            entity.fechaCreacion = DateTime.Now;
            entity.active = true;

            return await base.AddAsync(entity);
        }

        public override async Task<OperationResult> UpdateAsync(Autor entity)
        {
            if (entity.idAutor <= 0)
                return OperationResult.Failure("El Id del autor debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(entity.nombre))
                return OperationResult.Failure("El Nombre del autor debe ser completado.");

            if (string.IsNullOrWhiteSpace(entity.apellido))
                return OperationResult.Failure("El Apellido del autor debe ser completado.");

            if (entity.nombre.Length > 50)
                return OperationResult.Failure("El nombre del autor no puede contener más de 50 caracteres.");

            if (entity.apellido.Length > 50)
                return OperationResult.Failure("El apellido del autor no puede contener más de 50 caracteres.");

            if (!entity.active == null)
            {
                return OperationResult.Failure("El estado del autor debe ser especificado.");
            }

            if (!entity.active)
            {
                bool asignadoALibroActivo = await _context.Libros
                    .AnyAsync(l => l.autorId == entity.idAutor && l.active);
                if (asignadoALibroActivo)
                {
                    return OperationResult.Failure("No se puede desactivar el autor porque está asignado a un libro activo.");
                }
            }

            //if (await _context.Libros.AnyAsync(l => l.autorId == entity.idAutor && l.active == true && entity.active == true))
            //{
            //    return OperationResult.Failure("No se puede cambiar el estado del autor porque está asignado a un libro activo.");
            //}


            var autor = await _context.Autores.FindAsync(entity.idAutor);
            if (autor == null)
                return OperationResult.Failure("Autor no encontrado.");

            autor.nombre = entity.nombre;
            autor.apellido = entity.apellido;
            autor.usuarioMod = entity.usuarioMod;
            autor.fechaMod = DateTime.Now;
            autor.active = entity.active;

            return await base.UpdateAsync(autor);
        }

    } 
}
