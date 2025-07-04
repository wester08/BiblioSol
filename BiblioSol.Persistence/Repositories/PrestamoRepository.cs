﻿
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


            bool libroExists = await _context.Libros.AnyAsync(l => l.idLibro == entity.libroId
                                                               && (l.estadoId == 3
                                                               || l.estadoId == 4)
                                                               && l.active == true);
                
            

            if (libroExists)
            {
                return OperationResult.Failure($"El libro con ID {entity.libroId} se encuentra asignado o reservado a otro prestamo.");

            }


            return await base.AddAsync(entity);
        }

        public override async Task<OperationResult> UpdateAsync(Prestamo entity)
        {

            if (entity.libroId <= 0)
            {
                return OperationResult.Failure("El libro del préstamo debe ser completado.");
            }
            if (entity.usuarioMod <= 0)
            {
                return OperationResult.Failure("El usuario que modifico el préstamo debe ser completado.");
            }

            var prestamo = await _context.Prestamos.FindAsync(entity.idPrestamo);

            if (prestamo == null)
            {
                return OperationResult.Failure($"El préstamo con ID {entity.idPrestamo} no existe.");
            }

            prestamo.libroId = entity.libroId;
            prestamo.nombreCliente = entity.nombreCliente;
            prestamo.libroId = entity.libroId;
            prestamo.fechaCompromiso = entity.fechaCompromiso;
            prestamo.fechaDevolucion = entity.fechaDevolucion;
            prestamo.diasRetraso = entity.diasRetraso;
            prestamo.monto = entity.monto;
            prestamo.penalizado = entity.penalizado;
            prestamo.estadoId = entity.estadoId;
            prestamo.fechaMod = entity.fechaMod;
            prestamo.usuarioMod = entity.usuarioMod;
            prestamo.active = entity.active;




            return await base.UpdateAsync(prestamo);
        }
    }

}
