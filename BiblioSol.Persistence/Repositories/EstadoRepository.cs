

using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Persistence.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        private readonly BiblioContext _context;
        public EstadoRepository(BiblioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OperationResult> AddAsync(Estado entity)
        {
            if (string.IsNullOrWhiteSpace(entity.nombre))
            {
                return OperationResult.Failure("El Nombre del estado debe ser completado.");
            }
            if (entity.nombre.Length > 50)
            {
                return OperationResult.Failure("El nombre del estado no puede contener más de 50 caracteres.");
            }

            return await base.AddAsync(entity);
        }

        public override async Task<OperationResult> UpdateAsync(Estado entity)
        {
            if (entity.idEstado <= 0)
            {
                return OperationResult.Failure("El Id del estado debe ser mayor a cero.");
            }
            if (string.IsNullOrWhiteSpace(entity.nombre))
            {
                return OperationResult.Failure("El Nombre del estado debe ser completado.");
            }
            if (entity.nombre.Length > 50)
            {
                return OperationResult.Failure("El nombre del estado no puede contener más de 50 caracteres.");
            }

            var estado = await _context.Estados.FindAsync(entity.idEstado);
            if (estado == null)
            {
                return OperationResult.Failure($"El estado no existe.");
            }
            estado.nombre = entity.nombre;
            estado.fechaMod = entity.fechaMod;
            estado.usuarioMod = entity.usuarioMod;
            estado.active = entity.active;




            return await base.UpdateAsync(estado);
        }

    }

}
