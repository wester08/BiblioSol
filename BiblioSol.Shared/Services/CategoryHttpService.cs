

using BiblioSol.Shared.Configurations;
using System.Net.Http.Json;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BiblioSol.Shared.Dtos.CategoryDtos;

namespace BiblioSol.Shared.Services
{
    public class CategoryHttpService : ICategoryHttpService
    {
        private readonly HttpClient _client;
        private readonly ILogger<CategoryHttpService> _logger;

        public CategoryHttpService(HttpClient client, IOptions<ApiConfig> config, ILogger<CategoryHttpService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri(config.Value.BaseUrl);
        }

        public async Task<OperationResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {

            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<IEnumerable<CategoryDto>>>("Category/GetAllCategoria");
                if (result != null && result.isSuccess)
                {
                    return result;
                }
                else
                {
                    return new OperationResult<IEnumerable<CategoryDto>> { isSuccess = false, Message = "Failed to fetch categories" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching categories");
                return new OperationResult<IEnumerable<CategoryDto>> { isSuccess = false, Message = ex.Message };
            }
        }

        // Los demás métodos (GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync) siguen un patrón similar
        public async Task<OperationResult<CategoryDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<CategoryDto>>($"Category/GetCategoriaById?id={id}");
                if (result != null && result.isSuccess)
                {
                    return result;
                }
                else
                {
                    return new OperationResult<CategoryDto> { isSuccess = false, Message = "Failed to fetch category" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching category by ID");
                return new OperationResult<CategoryDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<AddCategoryDto>> AddAsync(AddCategoryDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Category/AddCategoria", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<AddCategoryDto>>();
                    return result ?? new OperationResult<AddCategoryDto> { isSuccess = false, Message = "Response null" };
                }
                else
                {
                    return new OperationResult<AddCategoryDto> { isSuccess = false, Message = "Failed to create category" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category");
                return new OperationResult<AddCategoryDto> { isSuccess = false, Message = ex.Message };
            }
        }
        public async Task<OperationResult<object>> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"Category/UpdateCategoriaById?id={id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult<object> { isSuccess = true };
                }
                else
                {
                    return new OperationResult<object> { isSuccess = false, Message = "Failed to update category" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category");
                return new OperationResult<object> { isSuccess = false, Message = ex.Message };
            }
        }

    }
}
