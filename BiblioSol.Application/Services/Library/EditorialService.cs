

using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Application.Extentions.Library;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BiblioSol.Application.Services.Library
{
    public class EditorialService : IEditorialSevice
    {
        private readonly IEditorialRepository _editorialRepository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public EditorialService(IEditorialRepository editorialRepository, 
                                ILogger<EditorialService> logger, 
                                IConfiguration configuration)
        {
            _editorialRepository = editorialRepository;
            _logger = logger;
            _configuration = configuration;
        }



        public async Task<OperationResult> GetAllEditorialAsync()
        {

            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Retrieving all editorials from the repository.");
                var result = await _editorialRepository.GetAllAsync(nt => nt.active);
                if (result.IsSuccess && result.Data is not null)
                {
                    var editorials = ((List<Editorial>)result.Data).ToList();
                    operationResult =  OperationResult.Success("Editorials retrieved successfully.", editorials);
                }
                else
                {
                    operationResult = OperationResult.Failure("No editorials found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving all editorials: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving editorials.");
            }
            return operationResult;

        }

        public async Task<OperationResult> GetEditorialByIdAsync(int id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation($"Retrieving editorial with ID {id} from the repository.");
                var result = await _editorialRepository.GetByIdAsync(id);
                if (result.IsSuccess && result.Data is not null)
                {
                    var editorial = (Editorial)result.Data;
                    operationResult = OperationResult.Success("Editorial retrieved successfully.", editorial);
                }
                else
                {
                    operationResult = OperationResult.Failure("Editorial not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving editorial by ID {id}: {ex.Message}", ex);
                 operationResult = OperationResult.Failure("An error occurred while retrieving the editorial.");
            }
            return operationResult;
        }
        public async Task<OperationResult> AddEditorialAsync(EditorialAddDto editorialAddDto)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation("Adding a new editorial to the repository.");
                if (editorialAddDto == null)
                {
                    return OperationResult.Failure("Editorial data cannot be null.");
                }
                if (await _editorialRepository.ExistsAsync(e => e.nombre == editorialAddDto.nombre))
                {
                    return OperationResult.Failure("An editorial with this name already exists.");
                }
                operationResult = await _editorialRepository.AddAsync(editorialAddDto.ToDomainEntityAdd());
       
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding editorial: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while adding the editorial.");
            }
            return operationResult;
        }

        public async Task<OperationResult> UpdateEditorialAsync(EditorialUpdateDto editorialUpdateDto)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation($"Updating editorial with ID {editorialUpdateDto.idEditorial} in the repository.");
                if (editorialUpdateDto == null)
                {
                    operationResult = OperationResult.Failure("Editorial data cannot be null.");
                }
                if (!await _editorialRepository.ExistsAsync(e => e.idEditorial == editorialUpdateDto.idEditorial))
                {
                    operationResult = OperationResult.Failure("Editorial not found.");
                }
                operationResult = await _editorialRepository.UpdateAsync(editorialUpdateDto.ToDomainEntityUpdate());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating editorial: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while updating the editorial.");
            }
            return operationResult;
        }
    }
}
