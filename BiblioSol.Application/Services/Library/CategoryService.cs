

using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Entities;
using BiblioSol.Domain.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BiblioSol.Application.Extentions.Library;

namespace BiblioSol.Application.Services.Library
{
    public class CategoryService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public CategoryService(ICategoriaRepository categoriaRepository,
                               ILogger<CategoryService> logger,
                               IConfiguration configuration)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAllCategoriaAsync()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Retrieving all categories from the repository.");
                var result = await _categoriaRepository.GetAllAsync(nt => nt.active);
                if (result.IsSuccess && result.Data is not null)
                {
                    var categories = ((List<Categoria>)result.Data).ToList();

                    operationResult = OperationResult.Success("Categories retrieved successfully.", categories);
                }
                else
                {
                    operationResult = OperationResult.Failure("No categories found.");
                }
                _logger.LogInformation("Successfully retrieved categories.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving all categories: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving categories.");
            }

            return operationResult;
        }

        public async Task<OperationResult> GetCategoriaByIdAsync(int id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation("Retrieving category with ID: {Id}", id);
                var result = await _categoriaRepository.GetByIdAsync(id);
                if (result.IsSuccess && result.Data is not null)
                {
                    var category = result.Data as Categoria;
                    operationResult = OperationResult.Success("Category retrieved successfully.", category);
                }
                else
                {
                    operationResult = OperationResult.Failure($"Category with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving category by ID: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while retrieving the category.");
            }
            return operationResult;
        }

        public async Task<OperationResult> AddCategoriaAsync(CategoriaAddDto categoriaAddDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Adding new category with description: {Description}", categoriaAddDto.descripcion);
                if (categoriaAddDto is null)
                {
                    var errorMessage = _configuration["Error:ErrorCategoryIsNull"] ?? "Error: Category is null.";
                    operationResult = OperationResult.Failure(errorMessage);
                    return operationResult;
                }

                if (await _categoriaRepository.ExistsAsync(nt => nt.descripcion == categoriaAddDto.descripcion))
                {
                    operationResult = OperationResult.Failure($"Category with the description {categoriaAddDto.descripcion} already exists.");
                    return operationResult;
                }

                operationResult = await _categoriaRepository.AddAsync(categoriaAddDto.ToDomainEntityAdd());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding category: {ex.Message}", ex);
            }
            return operationResult;
        }

        public async Task<OperationResult> UpdateCategoriaAsync(CategoriaUpdateDto categoriaUpdateDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Updating new category with description: {Description}", categoriaUpdateDto.descripcion);
                if (categoriaUpdateDto is null)
                {
                    operationResult = OperationResult.Failure("CategoriaAddDto cannot be null.");
                    return operationResult;
                }

                operationResult = await _categoriaRepository.UpdateAsync(categoriaUpdateDto.ToDomainEntityUpdate());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding category: {ex.Message}", ex);
            }
            return operationResult;
        }


    }

}
