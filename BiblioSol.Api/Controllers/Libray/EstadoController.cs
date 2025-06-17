using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.DTOs.Library.Estado;
using BiblioSol.Application.Interfaces.Services.Library;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiblioSol.Api.Controllers.Libray
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }
        // GET: api/<EstadoController>
        [HttpGet("GetAllEstados")]
        public async Task<IActionResult>  Get()
        {
            try
            {
                var result = await _estadoService.GetAllEstadosAsync();
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

        // GET api/<EstadoController>/5
        [HttpGet("GetAllEstadoById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _estadoService.GetEstadoByIdAsync(id);
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

        // POST api/<EstadoController>
        [HttpPost("AddEstado")]
        public async Task<IActionResult> Post([FromBody] EstadoAddDto estadoAddDto)
        {
            try
            {
                var result = await _estadoService.AddEstadoAsync(estadoAddDto);
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

        // PUT api/<EstadoController>/5
        [HttpPut("UpdateEstado")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadoUpdateDto estadoUpdateDto)
        {
            try
            {
                if (id != estadoUpdateDto.idEstado)
                {
                    return BadRequest(new { Message = "El ID de la categoría no coincide." });
                }
                var result = await _estadoService.UpdateEstadoAsync(estadoUpdateDto);
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
