

using BiblioSol.Application.DTOs.Library.Autor;
using BiblioSol.Domain.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
    public interface IAutorService
    {
        Task<OperationResult> GetAllAutorAsync();
        Task<OperationResult> GetAutorByIdAsync(int id);
        Task<OperationResult> AddAutorAsync(AutorAddDto autorAddDto);
        Task<OperationResult> UpdateAutorAsync(AutorUpdateDto autorUpdateDto);
    }
}
