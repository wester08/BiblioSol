using BiblioSol.Shared.Configurations;
using BiblioSol.Shared.Dtos.LibrosDtos;
using BiblioSol.Shared.Interfaces;
using BiblioSol.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace BiblioSol.Shared.Services
{
    public class LibroHttpService : ILibroHttpService
    {
        private readonly HttpClient _client;
        private readonly ILogger<LibroHttpService> _logger;

        public LibroHttpService(HttpClient client, IOptions<ApiConfig> config, ILogger<LibroHttpService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri(config.Value.BaseUrl);
        }

        public async Task<OperationResult<IEnumerable<LibroDto>>> GetAllAsync()
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<IEnumerable<LibroDto>>>("Libro/GetAllLibros");
                if (result != null && result.isSuccess)
                    return result;

                return new OperationResult<IEnumerable<LibroDto>> { isSuccess = false, Message = "Failed to fetch libros" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching libros");
                return new OperationResult<IEnumerable<LibroDto>> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<LibroDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<OperationResult<LibroDto>>($"Libro/GetLibroById?id={id}");
                if (result != null && result.isSuccess)
                    return result;

                return new OperationResult<LibroDto> { isSuccess = false, Message = "Failed to fetch libro" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching libro by ID");
                return new OperationResult<LibroDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<LibroAddDto>> AddAsync(LibroAddDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Libro/AddLibro", dto);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<LibroAddDto>>();
                    return result ?? new OperationResult<LibroAddDto> { isSuccess = false, Message = "Response null" };
                }

                return new OperationResult<LibroAddDto> { isSuccess = false, Message = "Failed to create libro" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating libro");
                return new OperationResult<LibroAddDto> { isSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult<object>> UpdateAsync(int id, LibroUpdateDto dto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"Libro/UpdateLibro?id={id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult<object> { isSuccess = true };
                }

                return new OperationResult<object> { isSuccess = false, Message = "Failed to update libro" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating libro");
                return new OperationResult<object> { isSuccess = false, Message = ex.Message };
            }
        }
    }
}
