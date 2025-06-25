
using BiblioSol.Shared.Dtos.EstadoDtos;
using BiblioSol.Shared.Models;

namespace BiblioSol.Shared.Interfaces
{
    public interface IEstadoHttpService
    {
        Task<OperationResult<IEnumerable<EstadoDto>>> GetAllAsync();
        Task<OperationResult<EstadoDto>> GetByIdAsync(int id);
        Task<OperationResult<EstadoAddDto>> AddAsync(EstadoAddDto dto);
        Task<OperationResult<object>> UpdateAsync(int id, EstadoUpdateDto dto);
    }
}
