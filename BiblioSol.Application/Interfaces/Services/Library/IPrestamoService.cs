

using BiblioSol.Application.DTOs.Library.Prestamo;
using BiblioSol.Domain.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
    public interface IPrestamoService
    {
        Task<OperationResult> GetAllPrestamosAsync();
        Task<OperationResult> GetPrestamoByIdAsync(int id);
        Task<OperationResult> AddPrestamoAsync(PrestamoAddDto prestamoAddDto);
        Task<OperationResult> UpdatePrestamoAsync(PrestamoUpdateDto prestamoUpdateDto);

        Task<OperationResult> SolicitarPrestamoAsync(PrestamoAddDto prestamoAddDto);

    }
}
