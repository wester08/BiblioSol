
using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Shared.Dtos.EditorialDtos;
using BiblioSol.Shared.Models;

namespace BiblioSol.Shared.Interfaces
{
    public interface IEditorialHttpService
    {
        Task<OperationResult<IEnumerable<EditorialDto>>> GetAllAsync();
        Task<OperationResult<EditorialDto>> GetByIdAsync(int id);
        Task<OperationResult<EditorialAddDto>> AddAsync(EditorialAddDto dto);
        Task<OperationResult<object>> UpdateAsync(int id, EditorialUpdateDto dto);
    }
}
