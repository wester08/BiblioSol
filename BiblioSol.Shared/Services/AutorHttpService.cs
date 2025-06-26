using BiblioSol.Shared.Configurations;
using BiblioSol.Shared.Dtos.AutorDtos;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace BiblioSol.Shared.Services
{
    public class AutorHttpService : IAutorHttpService
    {
        private readonly HttpClient _client;
        private readonly ILogger<AutorHttpService> _logger;

        public AutorHttpService(HttpClient client, IOptions<ApiConfig> config, ILogger<AutorHttpService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri(config.Value.BaseUrl);
        }

        public async Task<OperationResult<IEnumerable<AutorDto>>> GetAllAsync()
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<IEnumerable<AutorDto>>>("Autor/GetAllAutores");
                if (result != null && result.isSuccess)
                {
                    return result;
                }

                return new OperationResult<IEnumerable<AutorDto>> { isSuccess = false, Message = "Failed to fetch authors" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching authors");
                return new OperationResult<IEnumerable<AutorDto>> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<AutorDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<AutorDto>>($"Autor/GetAutorById?id={id}");
                if (result != null && result.isSuccess)
                {
                    return result;
                }

                return new OperationResult<AutorDto> { isSuccess = false, Message = "Failed to fetch author" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching author by ID");
                return new OperationResult<AutorDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<AutorAddDto>> AddAsync(AutorAddDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Autor/AddAutor", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<AutorAddDto>>();
                    return result ?? new OperationResult<AutorAddDto> { isSuccess = false, Message = "Response null" };
                }

                return new OperationResult<AutorAddDto> { isSuccess = false, Message = "Failed to create author" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating author");
                return new OperationResult<AutorAddDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<object>> UpdateAsync(int id, AutorUpdateDto dto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"Autor/UpdateAutor?id={id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult<object> { isSuccess = true };
                }

                return new OperationResult<object> { isSuccess = false, Message = "Failed to update author" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating author");
                return new OperationResult<object> { isSuccess = false, Message = ex.Message };
            }
        }
    }
}
