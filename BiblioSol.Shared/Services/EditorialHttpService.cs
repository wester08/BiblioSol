using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Shared.Configurations;
using BiblioSol.Shared.Dtos.EditorialDtos;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace BiblioSol.Shared.Services
{
    public class EditorialHttpService : IEditorialHttpService
    {
        private readonly HttpClient _client;
        private readonly ILogger<EditorialHttpService> _logger;

        public EditorialHttpService(HttpClient client, IOptions<ApiConfig> config, ILogger<EditorialHttpService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri(config.Value.BaseUrl);
        }

        public async Task<OperationResult<IEnumerable<EditorialDto>>> GetAllAsync()
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<IEnumerable<EditorialDto>>>("Editorial/GetAllEditoriales");
                return result ?? new OperationResult<IEnumerable<EditorialDto>> { isSuccess = false, Message = "Failed to fetch editorials" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching editorials");
                return new OperationResult<IEnumerable<EditorialDto>> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<EditorialDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<EditorialDto>>($"Editorial/GetEditorialById?id={id}");
                return result ?? new OperationResult<EditorialDto> { isSuccess = false, Message = "Failed to fetch editorial" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching editorial by ID");
                return new OperationResult<EditorialDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<EditorialAddDto>> AddAsync(EditorialAddDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Editorial/AddEditorial", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<EditorialAddDto>>();
                    return result ?? new OperationResult<EditorialAddDto> { isSuccess = false, Message = "Response null" };
                }

                return new OperationResult<EditorialAddDto> { isSuccess = false, Message = "Failed to create editorial" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating editorial");
                return new OperationResult<EditorialAddDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<object>> UpdateAsync(int id, EditorialUpdateDto dto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"Editorial/UpdateEditorial?id={id}", dto);
                return response.IsSuccessStatusCode
                    ? new OperationResult<object> { isSuccess = true }
                    : new OperationResult<object> { isSuccess = false, Message = "Failed to update editorial" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating editorial");
                return new OperationResult<object> { isSuccess = false, Message = ex.Message };
            }
        }
    }
}
