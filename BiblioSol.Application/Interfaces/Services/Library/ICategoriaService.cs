using BiblioSol.Domain.Entities;
using BiblioSol.Domin.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
    public interface ICategoriaService
    {
        Task<OperationResult> GetAllCategoriaAsync();
        Task<OperationResult> GetCategoriaByIdAsync(int id);
        Task<OperationResult> AddCategoriaAsync(Categoria categoria);
        Task<OperationResult> UpdateCategoriaAsync(Categoria categoria);
        Task<OperationResult> DeleteCategoriaAsync(int id);

    }
}
