

using BiblioSol.Application.Interfaces.Respositories;
using BiblioSol.Domin.Base;
using BiblioSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BiblioSol.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRespository<TEntity> where TEntity : class
    {
        private readonly BiblioContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(BiblioContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                var entities = await _dbSet.Where(filter).ToListAsync();
                Opresult = OperationResult.Success($"Entity {typeof(TEntity)} retrieved successfully", entities);


            }
            catch (Exception ex)
            {
                Opresult = OperationResult.Failure($"Error retrieving entities{typeof(TEntity)} : {ex.Message}");
            }
            return Opresult;

        }
        public virtual async Task<OperationResult> GetByIdAsync(int id)
        {
            OperationResult Opresult = new OperationResult();

            try
            {

                var entity = await _dbSet.FindAsync(id);

                if (entity == null)
                {
                    Opresult = OperationResult.Failure($"Entity {typeof(TEntity)} with ID {id} not found.");
                    return Opresult;
                }

                Opresult = OperationResult.Success($"Entity {typeof(TEntity)} retrieved successfully", entity);


            }
            catch (Exception ex)
            {
                Opresult = OperationResult.Failure($"Error retrieving entities{typeof(TEntity)} : {ex.Message}");
            }
            return Opresult;
        }
        public virtual async Task<OperationResult> AddAsync(TEntity entity)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                Opresult = OperationResult.Success($"Entity {typeof(TEntity)} added successfully", entity);
            }
            catch (Exception ex)
            {
                Opresult = OperationResult.Failure($"Error adding entity {typeof(TEntity)}: {ex.Message}");
            }
            return Opresult;

        }
        public virtual async Task<OperationResult> UpdateAsync(TEntity entity)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                Opresult = OperationResult.Success($"Entity {typeof(TEntity)} updated successfully", entity);
            }
            catch (Exception ex)
            {
                Opresult = OperationResult.Failure($"Error updating entity {typeof(TEntity)}: {ex.Message}");
            }
            return Opresult;
        }
        public virtual async Task<OperationResult> DisableAsync(TEntity entity)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                Opresult = OperationResult.Success($"Entity {typeof(TEntity)} updated successfully", entity);
            }
            catch (Exception ex)
            {
                Opresult = OperationResult.Failure($"Error updating entity {typeof(TEntity)}: {ex.Message}");
            }
            return Opresult;

        }
        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                var exists = await _dbSet.AnyAsync(filter);
                if (exists)
                {
                    Opresult = OperationResult.Success($"Entity {typeof(TEntity)} exists.");
                }
                else
                {
                    Opresult = OperationResult.Failure($"Entity {typeof(TEntity)} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Opresult = OperationResult.Failure($"Error checking existence of entity {typeof(TEntity)}: {ex.Message}");

            }
          
            return await _dbSet.AnyAsync(filter);
        }


    }
}
