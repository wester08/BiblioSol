

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
        private readonly ILibroRepository _libroRepository;

        public PrestamoService(IPrestamoRepository prestamoRepository,
                               ILogger<PrestamoService> logger,
                               IConfiguration configuration,
                               ILibroRepository libroRepository)
        {
            _prestamoRepository = prestamoRepository;
            _Logger = logger;
            _configuration = configuration;
            _libroRepository = libroRepository;
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

                try
                {
                    var libro = await _libroRepository.GetByIdAsync(prestamoAddDto.libroId);
                    if (libro.IsSuccess && libro.Data is not null)
                    {
                        var libroEntity = (Libro)libro.Data;
                        libroEntity.estadoId = 4;// Cambiar el estado a "PRESTADO"
                        libroEntity.fechaMod = DateTime.Now;
                        libroEntity.usuarioMod = prestamoAddDto.usuarioCreacionId; // Asignar el usuario que realiza la modificación

                        await _libroRepository.UpdateAsync(libroEntity);
                    }
                    else
                    {
                        _Logger.LogWarning($"No se encontró el libro con ID {prestamoAddDto.libroId} para actualizar su estado.");
                    }

                } catch (Exception ex) {
                    _Logger.LogError($"Error updating book status: {ex.Message}", ex);
                    operationResult = OperationResult.Failure("An error occurred while updating the book status.");
                }


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

                // Cambiar el estado del libro en la entidad Libros
                // Aquí se asume que el libro ya está reservado y se cambia su estado a "Prestado"
                // Esto puede requerir una llamada a otro repositorio o servicio para actualizar el estado del libro
                // Ejemplo:
                try
                {
                    var libro = await _libroRepository.GetByIdAsync(prestamoAddDto.libroId);
                    if (libro.IsSuccess && libro.Data is not null)
                    {
                        var libroEntity = (Libro)libro.Data;
                        libroEntity.estadoId = 3;// Cambiar el estado a "PRESTADO"
                        libroEntity.fechaMod = DateTime.Now;
                        libroEntity.usuarioMod = prestamoAddDto.usuarioCreacionId; // Asignar el usuario que realiza la modificación

                        await _libroRepository.UpdateAsync(libroEntity);
                    }
                    else
                    {
                        _Logger.LogWarning($"No se encontró el libro con ID {prestamoAddDto.libroId} para actualizar su estado.");
                    }
                }
                catch (Exception ex)
                {
                    _Logger.LogError($"Error updating book status: {ex.Message}", ex);
                    operationResult = OperationResult.Failure("An error occurred while updating the book status.");

                }



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
