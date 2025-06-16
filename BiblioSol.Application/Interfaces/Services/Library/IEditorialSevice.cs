

using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Domain.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
        public interface IEditorialSevice
    {
        Task<OperationResult> GetAllEditorialAsync();
        Task<OperationResult> GetEditorialByIdAsync(int id);
        Task<OperationResult> AddEditorialAsync(EditorialAddDto editorialAddDto);
        Task<OperationResult> UpdateEditorialAsync(EditorialUpdateDto editorialUpdateDto);
    }
}
