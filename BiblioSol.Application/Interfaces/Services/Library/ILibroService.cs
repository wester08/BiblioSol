

using BiblioSol.Application.DTOs.Library.Libro;
using BiblioSol.Domain.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
    public interface ILibroService
    {
        public Task<OperationResult> GetAllLibrosAsync();
        public Task<OperationResult> GetLibroByIdAsync(int id);
        public Task<OperationResult> AddLibroAsync(LibroAddDto libroAddDto);
        public Task<OperationResult> UpdateLibroAsync(LibroUpdateDto libroUpdateDto);

    }
}
