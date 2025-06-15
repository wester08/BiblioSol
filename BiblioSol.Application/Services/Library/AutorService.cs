
using BiblioSol.Application.DTOs.Library.Autor;
using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.Extentions.Library;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BiblioSol.Application.Services.Library
{
    public class AutorService : IAutorService
    {

        private readonly IAutorRepository _autorRepository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public AutorService(IAutorRepository autorRepository,
                               ILogger<CategoryService> logger,
                               IConfiguration configuration)
        {
            _autorRepository = autorRepository;
            _logger = logger;
            _configuration = configuration;
        }


        public async Task<OperationResult> GetAllAutorAsync()
        {

            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Retrieving all authors from the repository.");
                var result = await _autorRepository.GetAllAsync(nt => nt.active);
                if (result.IsSuccess && result.Data is not null)
                {
                    var authors = ((List<Autor>)result.Data).ToList();
                    operationResult = OperationResult.Success("Authors retrieved successfully.", authors);
                }
                else
                {
                    operationResult = OperationResult.Failure("No authors found.");
                }
                _logger.LogInformation("Successfully retrieved authors.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving all authors: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving authors.");
            }
            return operationResult;
        }

        public async Task<OperationResult> GetAutorByIdAsync(int id)
        {

            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Retrieving author with ID: {Id}", id);
                var result = await _autorRepository.GetByIdAsync(id);
                if (result.IsSuccess && result.Data is not null)
                {
                    var author = result.Data as Autor;
                    operationResult = OperationResult.Success("Author retrieved successfully.", author);
                }
                else
                {
                    operationResult = OperationResult.Failure($"Author with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving author by ID: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving the author.");
            }
            return operationResult;
        }

        public async Task<OperationResult> AddAutorAsync(AutorAddDto autorAddDto)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation("Adding new author with name: {Name}", autorAddDto.nombre);
                if (autorAddDto is null)
                {
                    var errorMessage = _configuration["Error:ErrorAuthorIsNull"] ?? "Error: Author is null.";
                    operationResult = OperationResult.Failure(errorMessage);
                    return operationResult;
                }
                if (await _autorRepository.ExistsAsync(nt => nt.nombre == autorAddDto.nombre))
                {
                    operationResult = OperationResult.Failure($"Author with the name {autorAddDto.nombre} already exists.");
                    return operationResult;
                }
                operationResult = await _autorRepository.AddAsync(autorAddDto.ToDomainEntityAdd());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding author: {ex.Message}", ex);
            }
            return operationResult;
        }


        public async Task<OperationResult> UpdateAutorAsync(AutorUpdateDto autorUpdateDto)
        {

            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Updating author with ID: {Id}", autorUpdateDto.idAutor);
                if (autorUpdateDto is null)
                {
                    operationResult = OperationResult.Failure("AutorUpdateDto cannot be null.");
                    return operationResult;
                }
                operationResult = await _autorRepository.UpdateAsync(autorUpdateDto.ToDomainEntityUpdate());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating author:  {ex.Message }", ex);
            }
            return operationResult;


        }



    }
}
