

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

                if (await _categoriaRepository.ExistsAsync(nt => nt.descripcion == categoriaAddDto.descripcion) !=null)
                {
                    operationResult = OperationResult.Failure("Category already exists with the same description.");
                    return operationResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding category: {ex.Message}", ex);
            }
            return operationResult;
        }

        public Task<OperationResult> AddCategoriaAsync(Categoria categoria)
        {
            
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeleteCategoriaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAllCategoriaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetCategoriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateCategoriaAsync(CategoriaUpdateDto categoriaUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
