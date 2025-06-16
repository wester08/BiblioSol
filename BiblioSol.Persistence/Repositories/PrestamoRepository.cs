
using BiblioSol.Application.Interfaces.Respositories;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BiblioSol.Persistence.Repositories
{
    public class PrestamoRepository : BaseRepository<Prestamo>, IPrestamoRepository
    {

        private readonly BiblioContext _context;
        public PrestamoRepository(BiblioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OperationResult> AddAsync(Prestamo entity)
        {
            if (entity.fechaCreacion == default)
            {
                return OperationResult.Failure("La fecha de préstamo debe ser completada.");
            }
            if (entity.fechaCompromiso == default)
            {
                return OperationResult.Failure("La fecha de compromiso debe ser completada.");
            }
            if (entity.libroId <= 0)
            {
                return OperationResult.Failure("El libro del préstamo debe ser completado.");
            }
            if (entity.usuarioCreacionId <= 0)
            {
                return OperationResult.Failure("El usuario del préstamo debe ser completado.");
            }


            var libroExists = await _context.Libros.AnyAsync(l => l.idLibro == entity.libroId && l.active == true);
            if (libroExists)
            {
                return OperationResult.Failure($"El libro con ID {entity.libroId} se encuentra asignado a otro prestamo.");

            }


            return await base.AddAsync(entity);
        }

        public override async Task<OperationResult> UpdateAsync(Prestamo entity)
        {
            if (entity.fechaMod == default)
            {
                return OperationResult.Failure("La fecha de préstamo debe ser completada.");
            }

            if (entity.libroId <= 0)
            {
                return OperationResult.Failure("El libro del préstamo debe ser completado.");
            }
            if (entity.usuarioMod <= 0)
            {
                return OperationResult.Failure("El usuario que modifico el préstamo debe ser completado.");
            }
            return await base.UpdateAsync(entity);
        }
    }

}
