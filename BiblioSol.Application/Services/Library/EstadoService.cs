

using BiblioSol.Application.DTOs.Library.Estado;
using BiblioSol.Application.Extentions.Library;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Base;
using BiblioSol.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BiblioSol.Application.Services.Library
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly ILogger _Logger;
        private readonly IConfiguration _configuration;
        public EstadoService(IEstadoRepository estadoRepository,
                             ILogger<EstadoService> logger,
                             IConfiguration configuration)
        {
            _estadoRepository = estadoRepository;
            _Logger = logger;
            _configuration = configuration;
        }
        public async Task<OperationResult> GetAllEstadosAsync()
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _Logger.LogInformation("Retrieving all states from the repository.");
                var result = await _estadoRepository.GetAllAsync(nt => nt.active);
                if (result.IsSuccess && result.Data is not null)
                {
                    var estados = ((List<Estado>)result.Data).ToList();
                    operationResult = OperationResult.Success("States retrieved successfully.", estados);
                }
                else
                {
                    operationResult = OperationResult.Failure("No states found.");
                }
                _Logger.LogInformation("Successfully retrieved states.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error retrieving all states: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving states.");
            }
            return operationResult;

        }

        public async Task<OperationResult> GetEstadoByIdAsync(int id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _Logger.LogInformation($"Retrieving state with ID {id} from the repository.");
                var result = await _estadoRepository.GetByIdAsync(id);
                if (result.IsSuccess && result.Data is not null)
                {
                    operationResult = OperationResult.Success("State retrieved successfully.", result.Data);
                }
                else
                {
                    operationResult = OperationResult.Failure("State not found.");
                }
                _Logger.LogInformation($"Successfully retrieved state with ID {id}.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error retrieving state by ID {id}: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving the state.");
            }
            return operationResult;
        }

        public async Task<OperationResult> AddEstadoAsync(EstadoAddDto estadoAddDto)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _Logger.LogInformation("Adding a new state to the repository.");
                if (estadoAddDto == null)
                {
                    return OperationResult.Failure("EstadoAddDto is null");
                }

                operationResult = await _estadoRepository.AddAsync(estadoAddDto.ToDomainEntityAdd());


                _Logger.LogInformation("Successfully added a new state.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error adding a new state: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while adding the state.");
            }
            return operationResult;
        }

        public async Task<OperationResult> UpdateEstadoAsync(EstadoUpdateDto estadoUpdateDto)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _Logger.LogInformation($"Updating state with ID {estadoUpdateDto.idEstado} in the repository.");
                if (estadoUpdateDto == null)
                {
                    operationResult = OperationResult.Failure("EstadoUpdateDto is null");
                    return operationResult;
                }


                operationResult = await _estadoRepository.UpdateAsync(estadoUpdateDto.ToDomainEntityUpdate());

                _Logger.LogInformation("Successfully updated estado.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error updating state with ID {estadoUpdateDto.idEstado}: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while updating the state.");
            }
            return operationResult;



        }
    }
}
