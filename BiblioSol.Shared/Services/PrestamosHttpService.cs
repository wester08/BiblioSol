using BiblioSol.Shared.Configurations;
using BiblioSol.Shared.Dtos;
using BiblioSol.Shared.Dtos.PrestamosDtos;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace BiblioSol.Shared.Services
{
    public class PrestamosHttpService : IPrestamoHttpService
    {
        private readonly HttpClient _client;
        private readonly ILogger<PrestamosHttpService> _logger;

        public PrestamosHttpService(HttpClient client, IOptions<ApiConfig> config, ILogger<PrestamosHttpService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri(config.Value.BaseUrl);
        }

        public async Task<OperationResult<IEnumerable<PrestamoDto>>> GetAllAsync()
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<IEnumerable<PrestamoDto>>>("Prestamo/GetAllPrestamos");
                if (result != null && result.isSuccess)
                {
                    return result;
                }

                return new OperationResult<IEnumerable<PrestamoDto>> { isSuccess = false, Message = "Failed to fetch prestamos" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching prestamos");
                return new OperationResult<IEnumerable<PrestamoDto>> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<PrestamoDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<PrestamoDto>>($"Prestamo/GetPrestamoById?id={id}");
                if (result != null && result.isSuccess)
                {
                    return result;
                }

                return new OperationResult<PrestamoDto> { isSuccess = false, Message = "Failed to fetch prestamo" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching prestamo by ID");
                return new OperationResult<PrestamoDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<PrestamoAddDto>> AddAsync(PrestamoAddDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Prestamo/AddPrestamo", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<PrestamoAddDto>>();
                    return result ?? new OperationResult<PrestamoAddDto> { isSuccess = false, Message = "Response null" };
                }

                return new OperationResult<PrestamoAddDto> { isSuccess = false, Message = "Failed to create prestamo" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating prestamo");
                return new OperationResult<PrestamoAddDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<PrestamoAddDto>> AddSolicitudAsync(PrestamoAddDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Prestamo/SolicitarPrestamo", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<PrestamoAddDto>>();
                    return result ?? new OperationResult<PrestamoAddDto> { isSuccess = false, Message = "Response null" };
                }

                return new OperationResult<PrestamoAddDto> { isSuccess = false, Message = "Failed to create prestamo" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating prestamo");
                return new OperationResult<PrestamoAddDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<object>> UpdateAsync(int id, PrestamoUpdateDto dto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"Prestamo/UpdatePrestamo?id={id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult<object> { isSuccess = true };
                }

                return new OperationResult<object> { isSuccess = false, Message = "Failed to update prestamo" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating prestamo");
                return new OperationResult<object> { isSuccess = false, Message = ex.Message };
            }
        }
    }
}
