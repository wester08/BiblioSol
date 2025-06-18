

using BiblioSol.Application.DTOs.Library.Estado;
using BiblioSol.Domain.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
    public interface IEstadoService
    {
        Task<OperationResult> GetAllEstadosAsync();
        Task<OperationResult> GetEstadoByIdAsync(int id);
        Task<OperationResult> AddEstadoAsync(EstadoAddDto estadoAddDto);
        Task<OperationResult> UpdateEstadoAsync(EstadoUpdateDto estadoUpdateDto);


    }
}
