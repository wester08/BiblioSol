

using BiblioSol.Shared.Dtos.LibrosDtos;
using BiblioSol.Shared.Dtos.PrestamosDtos;
using BiblioSol.Shared.Models;

namespace BiblioSol.Shared.Interfaces
{
    public interface ILibroHttpService
    {
        Task<OperationResult<IEnumerable<LibroDto>>> GetAllAsync();
        Task<OperationResult<LibroDto>> GetByIdAsync(int id);
        Task<OperationResult<LibroAddDto>> AddAsync(LibroAddDto dto);
        Task<OperationResult<object>> UpdateAsync(int id, LibroUpdateDto dto);


    }
}
