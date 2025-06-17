

using BiblioSol.Application.DTOs.Library.Prestamo;
using BiblioSol.Application.Extentions.Library;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BiblioSol.Application.Services.Library
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly ILogger _Logger;
        private readonly IConfiguration _configuration;

        public PrestamoService(IPrestamoRepository prestamoRepository,
                               ILogger<PrestamoService> logger,
                               IConfiguration configuration)
        {
            _prestamoRepository = prestamoRepository;
            _Logger = logger;
            _configuration = configuration;

        }



        public async Task<OperationResult> GetAllPrestamosAsync()
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _Logger.LogInformation("Retrieving all loans from the repository.");
                var result = await _prestamoRepository.GetAllAsync(nt => nt.active);
                if (result.IsSuccess && result.Data is not null)
                {
                    var prestamos = ((List<Prestamo>)result.Data).ToList();
                    operationResult = OperationResult.Success("Loans retrieved successfully.", prestamos);
                }
                else
                {
                    operationResult = OperationResult.Failure("No loans found.");
                }
                _Logger.LogInformation("Successfully retrieved loans.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error retrieving all loans: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving loans.");
            }
            return operationResult;
        }

        public async Task<OperationResult> GetPrestamoByIdAsync(int id)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _Logger.LogInformation($"Retrieving loan with ID {id} from the repository.");
                var result = await _prestamoRepository.GetByIdAsync(id);
                if (result.IsSuccess && result.Data is not null)
                {
                    var prestamo = (Prestamo)result.Data;
                    operationResult = OperationResult.Success("Loan retrieved successfully.", prestamo);
                }
                else
                {
                    operationResult = OperationResult.Failure($"No loan found with ID {id}.");
                }
                _Logger.LogInformation("Successfully retrieved loan.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error retrieving loan by ID {id}: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving the loan.");
            }
            return operationResult;
        }

        public async Task<OperationResult> AddPrestamoAsync(PrestamoAddDto prestamoAddDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _Logger.LogInformation("Adding new loan to the repository.");

                if (prestamoAddDto is null )
                {
                    _Logger.LogError("PrestamoAddDto is null.");
                    operationResult =  OperationResult.Failure("Loan data cannot be null.");

                }
                operationResult = await _prestamoRepository.AddAsync(prestamoAddDto.ToDomainEntityAdd());

                _Logger.LogInformation("Successfully added loan.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error adding new loan: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while adding the loan.");
            }
            return operationResult;
        }
        public async Task<OperationResult> UpdatePrestamoAsync(PrestamoUpdateDto prestamoUpdateDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _Logger.LogInformation("Updating loan in the repository.");
                if (prestamoUpdateDto is null)
                {
                    _Logger.LogError("PrestamoUpdateDto is null.");
                    operationResult = OperationResult.Failure("Loan data cannot be null.");
                }
                
                    operationResult = await _prestamoRepository.UpdateAsync(prestamoUpdateDto.ToDomainEntityUpdate());
                
                _Logger.LogInformation("Successfully updated loan.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error updating loan: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while updating the loan.");
            }
            return operationResult;
        }

        public async Task<OperationResult> SolicitarPrestamoAsync(PrestamoAddDto prestamoAddDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _Logger.LogInformation("Adding new request loan to the repository.");
                if (prestamoAddDto is null)
                {
                    _Logger.LogError("PrestamoAddDto is null.");
                    operationResult = OperationResult.Failure("Loan data cannot be null.");

                }
                operationResult = await _prestamoRepository.AddAsync(prestamoAddDto.ToDomainEntityAddReservar());


                _Logger.LogInformation("Successfully added loan.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error adding new loan: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while adding the loan.");
            }
            return operationResult;
        }
    }
}
