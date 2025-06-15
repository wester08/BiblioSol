using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Entities;
using BiblioSol.Domain.Base;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BiblioSol.Persistence.Repositories
{
    public sealed class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly BiblioContext _context;

        public CategoriaRepository(BiblioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OperationResult> AddAsync(Categoria entity)
        {
            if (string.IsNullOrWhiteSpace(entity.descripcion))
            {
                return OperationResult.Failure("La descripción de la categoría debe ser completada.");
            }

            if (entity.descripcion.Length > 50)
            {
                return OperationResult.Failure("La descripción de la categoría no puede contener más de 50 caracteres.");
            }

            var yaExiste = await ExistsAsync(c => c.descripcion == entity.descripcion);
            if (yaExiste)
            {
                return OperationResult.Failure($"La categoría {entity.descripcion} ya se encuentra registrada.");
            }

            return await base.AddAsync(entity);
        }

        public override async Task<OperationResult> UpdateAsync(Categoria entity)
        {
            if (entity.idCategoria <= 0)
            {
                return OperationResult.Failure("El Id de la categoría debe ser mayor a cero.");
            }

            if (string.IsNullOrWhiteSpace(entity.descripcion))
            {
                return OperationResult.Failure("La descripción de la categoría debe ser completada.");
            }

            if (entity.descripcion.Length > 50)
            {
                return OperationResult.Failure("La descripción de la categoría no puede contener más de 50 caracteres.");
            }

            if (!entity.active)
            {
                bool asignadaALibroActivo = await _context.Libros
                    .AnyAsync(l => l.categoriaId == entity.idCategoria && l.active);

                if (asignadaALibroActivo)
                {
                    return OperationResult.Failure("No se puede desactivar la categoría porque está asignada a un libro activo.");
                }
            }


            //if (await _context.Libros.AnyAsync(l => l.categoriaId == entity.idCategoria && l.active == true && entity.active == true))
            //{
            //    return OperationResult.Failure("No se puede cambiar el estado de la categoria porque está asignada a un libro activo.");
            //}

            var categoria = await _context.Categorias.FindAsync(entity.idCategoria);
            if (categoria == null)
            {
                return OperationResult.Failure("Categoría no encontrada.");
            }

            categoria.descripcion = entity.descripcion;
            categoria.usuarioMod = entity.usuarioMod;
            categoria.fechaMod = entity.fechaMod;
            categoria.active = entity.active;

            return await base.UpdateAsync(categoria);
        }


    }
}
