

using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.Extentions.Library.Category;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Entities;
using BiblioSol.Domin.Base;
using Microsoft.Extensions.Logging;

namespace BiblioSol.Application.Services.Library.Category
{
    public class CategoryService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ILogger _logger;
        public CategoryService(ICategoriaRepository categoriaRepository, ILogger<CategoryService> logger)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }
        public async Task<OperationResult> AddCategoriaAsync(CategoriaAddDto categoriaAddDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Adding new category with description: {Description}", categoriaAddDto.descripcion);
                if (categoriaAddDto is null)
                {
                    operationResult = OperationResult.Failure("CategoriaAddDto cannot be null.");
                    return operationResult;
                }

                if (await _categoriaRepository.ExistsAsync(nt => nt.descripcion == categoriaAddDto.descripcion))
                {
                    operationResult = OperationResult.Failure($"Category with the description {categoriaAddDto.descripcion} already exists.");
                    return operationResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding category: {ex.Message}", ex);
            }
            return operationResult;
        }

        public async Task<OperationResult> GetAllCategoriaAsync()
        {
            OperationResult operationResult = new OperationResult();

            try
            { 
                _logger.LogInformation("Retrieving all categories from the repository.");
                var result = await _categoriaRepository.GetAllAsync(nt => nt.isActive);
                if (result.IsSuccess && result.Data is not null)
                {
                    var categories = result.Data.Cast<Categoria>().ToList();
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

        public async Task<OperationResult> UpdateCategoriaAsync(CategoriaUpdateDto categoriaUpdateDto)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                _logger.LogInformation("Adding new category with description: {Description}", categoriaUpdateDto.descripcion);
                if (categoriaUpdateDto is null)
                {
                    operationResult = OperationResult.Failure("CategoriaAddDto cannot be null.");
                    return operationResult;
                }

                if (await _categoriaRepository.ExistsAsync(nt => nt.descripcion == categoriaUpdateDto.descripcion))
                {
                    operationResult = OperationResult.Failure($"Category with the description {categoriaUpdateDto.descripcion} already exists.");
                    return operationResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding category: {ex.Message}", ex);
            }
            return operationResult;
        }


        public async Task<OperationResult> DisableCategoriaAsync(int id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                _logger.LogInformation("Deleting category with ID: {Id}", id);
                var category = await _categoriaRepository.GetByIdAsync(id);
                if (category.IsSuccess && category.Data is not null)
                {
                    var result = await _categoriaRepository.DisableAsync(category.Data as Categoria);
                    if (result.IsSuccess)
                    {
                        operationResult = OperationResult.Success("Category deleted successfully.");
                    }
                    else
                    {
                        operationResult = OperationResult.Failure("Failed to delete the category.");
                    }
                }
                else
                {
                    operationResult = OperationResult.Failure($"Category with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting category: {ex.Message}", ex);
                operationResult = OperationResult.Failure("An error occurred while deleting the category.");
            }
            return operationResult;
        }

    }
    
}
