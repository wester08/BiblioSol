using BiblioSol.Application.DTOs.Library.Libro;
using BiblioSol.Application.Interfaces.Services.Library;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Api.Controllers.Libray
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // GET: api/Libro/GetAllLibros
        [HttpGet("GetAllLibros")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _libroService.GetAllLibrosAsync();
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Ha ocurrido un error inesperado.",
                    Details = ex.Message
                });
            }
        }

        // GET: api/Libro/GetLibroById?id=5
        [HttpGet("GetLibroById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _libroService.GetLibroByIdAsync(id);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Ha ocurrido un error inesperado.",
                    Details = ex.Message
                });
            }
        }

        // POST: api/Libro/AddLibro
        [HttpPost("AddLibro")]
        public async Task<IActionResult> Post([FromBody] LibroAddDto libroAddDto)
        {
            try
            {
                var result = await _libroService.AddLibroAsync(libroAddDto);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Ha ocurrido un error inesperado. Intente nuevamente más tarde.",
                    Details = ex.Message
                });
            }
        }

        // PUT: api/Libro/UpdateLibro?id=5
        [HttpPut("UpdateLibro")]
        public async Task<IActionResult> Put(int id, [FromBody] LibroUpdateDto libroUpdateDto)
        {
            try
            {
                if (id != libroUpdateDto.idLibro)
                {
                    return BadRequest(new
                    {
                        Message = "El ID del libro en la URL no coincide con el ID en el cuerpo de la solicitud."
                    });
                }

                var result = await _libroService.UpdateLibroAsync(libroUpdateDto);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Ha ocurrido un error inesperado. Intente nuevamente más tarde.",
                    Details = ex.Message
                });
            }
        }
    }
}
