

using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Persistence.Repositories
{
    public sealed class EditorialRepository : BaseRepository<Editorial>, IEditorialRepository
    {
        private readonly BiblioContext _context;

        public EditorialRepository(BiblioContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<OperationResult> AddAsync(Editorial entity)
        {
            if (string.IsNullOrWhiteSpace(entity.nombre))
                return OperationResult.Failure("El nombre de la editorial debe ser completado.");

            if (entity.nombre.Length > 50)
                return OperationResult.Failure("El nombre de la editorial no puede contener más de 50 caracteres.");

            var existe = await _context.Editoriales.AnyAsync(e => e.nombre == entity.nombre);
            if (existe)
                return OperationResult.Failure($"La editorial '{entity.nombre}' ya se encuentra registrada.");

            entity.fechaCreacion = DateTime.Now;
            entity.active = true;

            return await base.AddAsync(entity);
        }

        public override async Task<OperationResult> UpdateAsync(Editorial entity)
        {
            if (entity.idEditorial <= 0)
                return OperationResult.Failure("El Id de la editorial debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(entity.nombre))
                return OperationResult.Failure("El nombre de la editorial debe ser completado.");

            if (entity.nombre.Length > 50)
                return OperationResult.Failure("El nombre de la editorial no puede contener más de 50 caracteres.");

            if (!entity.active)
            {
                bool existeLibros = await _context.Libros.AnyAsync(l => l.editorialId == entity.idEditorial && l.active == true);
                if (existeLibros)
                {
                    return OperationResult.Failure("No se puede desactivar la editorial porque tiene libros asociados.");
                }

            }

            var editorial = await _context.Editoriales.FindAsync(entity.idEditorial);
            if (editorial == null)
                return OperationResult.Failure("Editorial no encontrada.");

            editorial.nombre = entity.nombre;
            editorial.usuarioMod = entity.usuarioMod;
            editorial.fechaMod = entity.fechaMod;
            editorial.active = entity.active;

            return await base.UpdateAsync(editorial);
        }



    }
}
