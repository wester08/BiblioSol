using BiblioSol.Application.DTOs.Library.Libro;
using BiblioSol.Application.DTOs.Library.Prestamo;
using BiblioSol.Application.Interfaces.Services.Library;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiblioSol.Api.Controllers.Libray
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {

        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }
        // GET: api/<PrestamoController>
        [HttpGet("GetAllPrestamos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _prestamoService.GetAllPrestamosAsync();
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

        // GET api/<PrestamoController>/5
        [HttpGet("GetPrestamoById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _prestamoService.GetPrestamoByIdAsync(id);
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

        // POST api/<PrestamoController>
        [HttpPost("AddPrestamo")]
        public async Task<IActionResult> Post([FromBody] PrestamoAddDto prestamoAddDto)
        {
            try
            {
                var result = await _prestamoService.AddPrestamoAsync(prestamoAddDto);
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

        // PUT api/<PrestamoController>/5
        [HttpPut("UpdatePrestamo")]
        public async Task<IActionResult> Put(int id, [FromBody] PrestamoUpdateDto prestamoUpdateDto)
        {
            try
            {
                if (id != prestamoUpdateDto.idPrestamo)
                {
                    return BadRequest(new
                    {
                        Message = "El ID del prestamo en la URL no coincide con el ID en el cuerpo de la solicitud."
                    });
                }
                var result = await _prestamoService.UpdatePrestamoAsync(prestamoUpdateDto);
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

    }
}
