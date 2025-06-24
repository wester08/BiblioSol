using BiblioSol.Shared.Dtos;
using BiblioSol.Shared.Dtos.PrestamosDtos;
using BiblioSol.Shared.Models;

namespace BiblioSol.Shared.Interfaces
{
    public interface IPrestamoHttpService
    {
        Task<OperationResult<IEnumerable<PrestamoDto>>> GetAllAsync();
        Task<OperationResult<PrestamoDto>> GetByIdAsync(int id);
        Task<OperationResult<PrestamoAddDto>> AddAsync(PrestamoAddDto dto);
        Task<OperationResult<object>> UpdateAsync(int id, PrestamoUpdateDto dto);
    }
}
