

using BiblioSol.Shared.Dtos;
using BiblioSol.Shared.Models;

namespace BiblioSol.Shared.Interfaces
{
    public interface ICategoryHttpService
    {
        Task<OperationResult<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<OperationResult<CategoryDto>> GetByIdAsync(int id);
        Task<OperationResult<AddCategoryDto>> AddAsync(AddCategoryDto dto);
        Task<OperationResult<object>> UpdateAsync(int id, UpdateCategoryDto dto);

    }
}
