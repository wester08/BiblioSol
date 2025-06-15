using BiblioSol.Application.DTOs.Library.Autor;
using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.Interfaces.Services.Library;
using Microsoft.AspNetCore.Mvc;


namespace BiblioSol.Api.Controllers.Libray
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: api/<AutorController>
        [HttpGet("GetAllAutores")]
        public async Task<IActionResult> Get()
        {

            try
            {
                var result = await _autorService.GetAllAutorAsync();
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

        // GET api/<AutorController>/5
        [HttpGet("GetAutorById")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var result = await _autorService.GetAutorByIdAsync(id);
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

        // POST api/<AutorController>
        [HttpPost("AddAutor")]
        public async Task<IActionResult>  Post([FromBody] AutorAddDto autorAddDto)
        {

            try
            {
                var result = await _autorService.AddAutorAsync(autorAddDto);
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

        // PUT api/<AutorController>/5
        [HttpPut("UpdateAutor")]
        public async Task<IActionResult> Put(int id, [FromBody] AutorUpdateDto autorUpdateDto)
        {
            try
            {
                if (id != autorUpdateDto.idAutor)
                {
                    return BadRequest(new { Message = "El ID del autor en la URL no coincide con el ID en el cuerpo de la solicitud." });
                }
                var result = await _autorService.UpdateAutorAsync(autorUpdateDto);
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
