using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Entities;
using BiblioSol.Domin.Base;
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

            var categoriaExistente = await _context.Categorias.FindAsync(entity.idCategoria);
            if (categoriaExistente == null)
            {
                return OperationResult.Failure("Categoría no encontrada.");
            }

            categoriaExistente.descripcion = entity.descripcion;
            categoriaExistente.usuarioMod = entity.usuarioMod;
            categoriaExistente.fechaMod = entity.fechaMod;

            return await base.UpdateAsync(categoriaExistente);
        }

        public async Task<OperationResult> CambiarEstadoAsync(int idCategoria, bool isActive, int usuarioModifico, DateTime fechaModificacion)
        {
            if (idCategoria <= 0)
            {
                return OperationResult.Failure("El Id de la categoría debe ser mayor a cero.");
            }

            var categoria = await _context.Categorias.FindAsync(idCategoria);
            if (categoria == null)
            {
                return OperationResult.Failure("Categoría no encontrada.");
            }

            var tieneLibros = await _context.Libros.AnyAsync(l => l.categoriaId == idCategoria);
            if (tieneLibros && !isActive)
            {
                return OperationResult.Failure("No se puede desactivar la categoría porque está asignada a libros.");
            }

            categoria.active = isActive;
            categoria.usuarioMod = usuarioModifico;
            categoria.fechaMod = fechaModificacion;

            return await base.DisableAsync(categoria); 
        }

        public async Task<OperationResult> ObtenerPorIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<OperationResult> ObtenerTodosAsync()
        {
            return await base.GetAllAsync(_ => true); 
        }
    }
}
