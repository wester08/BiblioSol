using BiblioSol.Shared.Configurations;
using BiblioSol.Shared.Dtos.EstadoDtos;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace BiblioSol.Shared.Services
{
    public class EstadoHttpService : IEstadoHttpService
    {
        private readonly HttpClient _client;
        private readonly ILogger<EstadoHttpService> _logger;

        public EstadoHttpService(HttpClient client, IOptions<ApiConfig> config, ILogger<EstadoHttpService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri(config.Value.BaseUrl);
        }

        public async Task<OperationResult<IEnumerable<EstadoDto>>> GetAllAsync()
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<IEnumerable<EstadoDto>>>("Estado/GetAllEstados");
                if (result != null && result.isSuccess)
                    return result;

                return new OperationResult<IEnumerable<EstadoDto>> { isSuccess = false, Message = "Failed to fetch estados" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching estados");
                return new OperationResult<IEnumerable<EstadoDto>> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<EstadoDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<EstadoDto>>($"Estado/GetAllEstadoById?id={id}");
                if (result != null && result.isSuccess)
                    return result;

                return new OperationResult<EstadoDto> { isSuccess = false, Message = "Failed to fetch estado" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching estado by ID");
                return new OperationResult<EstadoDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<EstadoAddDto>> AddAsync(EstadoAddDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Estado/AddEstado", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<EstadoAddDto>>();
                    return result ?? new OperationResult<EstadoAddDto> { isSuccess = false, Message = "Response null" };
                }

                return new OperationResult<EstadoAddDto> { isSuccess = false, Message = "Failed to create estado" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating estado");
                return new OperationResult<EstadoAddDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<object>> UpdateAsync(int id, EstadoUpdateDto dto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"Estado/UpdateEstado?id={id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult<object> { isSuccess = true };
                }

                return new OperationResult<object> { isSuccess = false, Message = "Failed to update estado" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating estado");
                return new OperationResult<object> { isSuccess = false, Message = ex.Message };
            }
        }
    }
}
