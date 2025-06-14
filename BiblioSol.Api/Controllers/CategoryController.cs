using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.Interfaces.Services.Library;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiblioSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;


        public CategoryController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;

        }

        // GET: api/<CategoryController>
        [HttpGet("GetAllCategoria")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _categoriaService.GetAllCategoriaAsync();
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

        // GET api/<CategoryController>/5
        [HttpGet("GetCategoriaById")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var result = await _categoriaService.GetCategoriaByIdAsync(id);
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

        // POST api/<CategoryController>
        [HttpPost("AddCategoria")]
        public async Task<IActionResult> Post([FromBody] CategoriaAddDto categoriaAddDto)
        {
            try
            {
                var result = await _categoriaService.AddCategoriaAsync(categoriaAddDto);

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

        // PUT api/<CategoryController>/5
        [HttpPut("UpdateCategoriaById")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaUpdateDto categoriaUpdateDto)
        {
            try
            {
                if (id != categoriaUpdateDto.idCategoria)
                {
                    return BadRequest(new { Message = "El ID de la categoría no coincide." });
                }
                var result = await _categoriaService.UpdateCategoriaAsync(categoriaUpdateDto);
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

        // DELETE api/<CategoryController>/5
        [HttpDelete("UpdateCategoriaById")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await _categoriaService.DisableCategoriaAsync(id);
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
