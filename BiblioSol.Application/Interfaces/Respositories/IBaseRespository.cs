

using BiblioSol.Domin.Base;
using System.Linq.Expressions;

namespace BiblioSol.Application.Interfaces.Respositories
{
    public interface IBaseRespository<TEntity> where TEntity : class
    {
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> GetByIdAsync(int id);
        Task<OperationResult> AddAsync(TEntity entity);
        Task<OperationResult> UpdateAsync(TEntity entity);
        Task<OperationResult> DisableAsync(TEntity entity);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);

        //Task<OperationResult> ExistsAsync (Expression<Func<bool>> filter);
    }
}
