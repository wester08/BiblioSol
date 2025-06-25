using BiblioSol.Shared.Dtos.EstadoDtos;
using BiblioSol.Shared.Extensions;
using BiblioSol.Shared.Extensions.Library;
using BiblioSol.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Web.Controllers.Libray
{
    public class EstadoController : Controller
    {
        private readonly IEstadoHttpService _service;

        public EstadoController(IEstadoHttpService service)
        {
            _service = service;
        }

        // GET: /Estado/GetAllEstados
        public async Task<IActionResult> GetAllEstados()
        {
            var result = await _service.GetAllAsync();
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new List<EstadoDto>());
        }

        // GET: /Estado/FormSearchByIdEstado
        public ActionResult FormSearchByIdEstado()
        {
            return View();
        }

        // GET: /Estado/GetEstadoById?id=1
        public async Task<IActionResult> GetEstadoById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new EstadoDto());
        }

        // GET: /Estado/AddEstado
        public IActionResult AddEstado()
        {
            return View();
        }

        // POST: /Estado/AddEstado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEstado(EstadoAddDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.AddAsync(dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllEstados));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }

        // GET: /Estado/UpdateEstadoById/5
        public async Task<IActionResult> UpdateEstadoById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                var updateDto = result.Data.ToUpdateEstadoDto();
                return View(updateDto);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return RedirectToAction(nameof(GetAllEstados));
        }

        // POST: /Estado/UpdateEstadoById/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEstadoById(int id, EstadoUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.idEstado = id;

            var result = await _service.UpdateAsync(id, dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllEstados));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }
    }
}
