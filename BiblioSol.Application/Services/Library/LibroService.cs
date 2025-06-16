

using BiblioSol.Application.DTOs.Library.Libro;
using BiblioSol.Application.Extentions.Library;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BiblioSol.Application.Services.Library
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public LibroService(ILibroRepository libroRepository,
                            ILogger<LibroService> logger,
                            IConfiguration configuration)
        {
            _libroRepository = libroRepository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAllLibrosAsync()
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation("Retrieving all books from the repository.");
                var result = await _libroRepository.GetAllAsync(nt => nt.active);
                if (result.IsSuccess && result.Data is not null)
                {
                    var libros = ((List<Libro>)result.Data).ToList();
                    operationResult = OperationResult.Success("Books retrieved successfully.", libros);
                }
                else
                {
                    operationResult = OperationResult.Failure("No books found.");
                }
                _logger.LogInformation("Successfully retrieved books.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving all books: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving books.");
            }
            return operationResult;
        }

        public async Task<OperationResult> GetLibroByIdAsync(int id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation($"Retrieving book with ID {id} from the repository.");
                var result = await _libroRepository.GetByIdAsync(id);
                if (result.IsSuccess && result.Data is not null)
                {
                    var libro = (Libro)result.Data;
                    operationResult = OperationResult.Success("Book retrieved successfully.", libro);
                }
                else
                {
                    operationResult = OperationResult.Failure("Book not found.");
                }
                _logger.LogInformation("Successfully retrieved book.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving book by ID {id}: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving the book.");
            }
            return operationResult;
        }

        public async Task<OperationResult> AddLibroAsync(LibroAddDto libroAddDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Adding a new book to the repository.");
                if (libroAddDto == null)
                {
                    _logger.LogWarning("LibroAddDto is null.");
                    return OperationResult.Failure("Invalid book data provided.");
                }

                if (await _libroRepository.ExistsAsync(l => l.titulo == libroAddDto.titulo))
                {
                    _logger.LogWarning($"Book with title '{libroAddDto.titulo}' already exists.");
                    return OperationResult.Failure($"A book with the title '{libroAddDto.titulo}' already exists.");
                }

                operationResult = await _libroRepository.AddAsync(libroAddDto.ToDomainEntityAdd());
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding book: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while adding the book.");
            }
            return operationResult;
        }


        public async Task<OperationResult> UpdateLibroAsync(LibroUpdateDto libroUpdateDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation($"Updating book with ID {libroUpdateDto.idLibro} in the repository.");
                if (libroUpdateDto == null)
                {
                    _logger.LogWarning("LibroUpdateDto is null.");
                    return OperationResult.Failure("Invalid book data provided.");
                }
                var existingLibro = await _libroRepository.GetByIdAsync(libroUpdateDto.idLibro);
                if (!existingLibro.IsSuccess || existingLibro.Data is null)
                {
                    _logger.LogWarning($"Book with ID {libroUpdateDto.idLibro} not found.");
                    return OperationResult.Failure("Book not found.");
                }
                operationResult = await _libroRepository.UpdateAsync(libroUpdateDto.ToDomainEntityUpdate());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating book: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while updating the book.");
            }
            return operationResult;
        }
    }
}
