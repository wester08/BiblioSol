using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Application.Interfaces.Services.Library;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Api.Controllers.Libray
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialSevice _editorialService;

        public EditorialController(IEditorialSevice editorialService)
        {
            _editorialService = editorialService;
        }

        // GET: api/Editorial/GetAllEditoriales
        [HttpGet("GetAllEditoriales")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _editorialService.GetAllEditorialAsync();
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

        // GET: api/Editorial/GetEditorialById?id=5
        [HttpGet("GetEditorialById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _editorialService.GetEditorialByIdAsync(id);
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

        // POST: api/Editorial/AddEditorial
        [HttpPost("AddEditorial")]
        public async Task<IActionResult> Post([FromBody] EditorialAddDto editorialAddDto)
        {
            try
            {
                var result = await _editorialService.AddEditorialAsync(editorialAddDto);
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

        // PUT: api/Editorial/UpdateEditorial?id=5
        [HttpPut("UpdateEditorial")]
        public async Task<IActionResult> Put(int id, [FromBody] EditorialUpdateDto editorialUpdateDto)
        {
            try
            {
                if (id != editorialUpdateDto.idEditorial)
                {
                    return BadRequest(new { Message = "El ID de la editorial en la URL no coincide con el ID en el cuerpo de la solicitud." });
                }

                var result = await _editorialService.UpdateEditorialAsync(editorialUpdateDto);
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
