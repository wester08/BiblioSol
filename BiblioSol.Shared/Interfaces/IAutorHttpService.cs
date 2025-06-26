


using BiblioSol.Shared.Dtos.AutorDtos;
using BiblioSol.Shared.Models;

namespace BiblioSol.Shared.Interfaces
{
    public interface IAutorHttpService
    {
        Task<OperationResult<IEnumerable<AutorDto>>> GetAllAsync();
        Task<OperationResult<AutorDto>> GetByIdAsync(int id);
        Task<OperationResult<AutorAddDto>> AddAsync(AutorAddDto dto);
        Task<OperationResult<object>> UpdateAsync(int id, AutorUpdateDto dto);
    }
}


